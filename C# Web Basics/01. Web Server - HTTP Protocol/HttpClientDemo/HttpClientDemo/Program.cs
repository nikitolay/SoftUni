using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace HttpClientDemo
{
    internal class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();//string - number of session
        const string NewLine = "\r\n";
        static async Task Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);//loopack==localhost,open port 80
            tcpListener.Start();//give me this port 80 and start work  

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();//the readline on tcp//read client
                ProcessClient(client);
            }


        }

        public static void ProcessClient(TcpClient client)
        {
            using var stream = client.GetStream();//to the client take a stream  

            byte[] buffer = new byte[1000000];
            var length = stream.Read(buffer, 0, buffer.Length);

            string requestString = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(requestString);

            var sid = Guid.NewGuid().ToString();
            var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage.Add(sid, 0);
            }
            SessionStorage[sid]++;//count of open given page

            string html = $"<h1> Hello from NikiServer {DateTime.Now} for the {SessionStorage[sid]} time</h1>" +
                   $"<form method=post><input name=username /><input name=password />" +
                   $"<input type=submit /></form>" + DateTime.Now;

            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: NikiServer 2022" + NewLine +
                // "Location: https://google.com" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
               $"Set-Cookie: {sid}; HttpOnly; Max-Age=" + (100 * 24 * 60 * 60) + NewLine +
                "Content-Lenght: " + html.Length + NewLine +
                NewLine +
                html +
                NewLine;


            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes);

            Console.WriteLine(new string('=', 70));
        }
        public static async Task ProcessClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();//to the client take a stream  

            byte[] buffer = new byte[1000000];
            var length = await stream.ReadAsync(buffer, 0, buffer.Length);


            string html = $"<h1> Hello from NikiServer {DateTime.Now}</h1>" +
                  $"<form method=post><input name=username /><input name=password />" +
                  $"<input type=submit /></form>" + DateTime.Now;

            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: NikiServer 2022" + NewLine +
                // "Location: https://google.com" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                "Content-Lenght: " + html.Length + NewLine +
                NewLine +
                html +
                NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('=', 70));
        }
        public async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));
        }
    }
}
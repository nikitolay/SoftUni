using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpClientDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);//loopack==localhost,open port 80
            tcpListener.Start();//give me this port 80 and start work  

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();//the readline on tcp//read client
                using var stream = client.GetStream();//to the client take a stream   

                int byteLenght = 0;
                byte[] buffer = new byte[100000];
                var lenght = stream.Read(buffer, byteLenght, buffer.Length);

                string requestString = Encoding.UTF8.GetString(buffer, 0, lenght); //convert what the client wrote you into a byte array

                Console.WriteLine(requestString);

                Thread.Sleep(5000);

                string html = $"<h1> Hello from NikiServer {DateTime.Now}</h1>" +
                    $"<form method=post><input name=username /><input name=password />" +
                    $"<input type=submit /></form>"+DateTime.Now;

                string response = "HTTP/1.1 200 OK" + NewLine +
                    "Server: NikiServer 2022" + NewLine +
                    // "Location: https://google.com" + NewLine +
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "Content-Lenght: " + html.Length + NewLine +
                    NewLine +
                    html +
                    NewLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);

                Console.WriteLine(new string('*', 70));
            }


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
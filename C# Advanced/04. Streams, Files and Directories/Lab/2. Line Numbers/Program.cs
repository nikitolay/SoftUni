using System;
using System.IO;

namespace _2._Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("input.txt");
            string line = streamReader.ReadLine();
            int index = 1;
            while (true)
            {
                if (line == null)
                {
                    break;
                }
                File.AppendAllText("output.txt", $"{index++}. {line}{Environment.NewLine}");
                line = streamReader.ReadLine();
            }
        }
    }
}

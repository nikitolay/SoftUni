using System;
using System.IO;

namespace _1._Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("input.txt");


            string line = streamReader.ReadLine();
            int index = 0;
            while (true)
            {
                if (line == null)
                {
                    break;
                }
                if (index % 2 != 0)
                {

                    File.AppendAllText("output.txt", line + Environment.NewLine);
                }
                line = streamReader.ReadLine();
                index++;
            }

        }
    }
}

using System;
using System.IO;

namespace _5._Slice_a_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("sliceMe.txt", FileMode.Open);

            int filePart = (int)Math.Ceiling(reader.Length / 4.0);
            byte[] buffer = new byte[4096];

            for (int i = 1; i <= 4; i++)
            {
                int totalWrite = 0;
                string fileName = $"slice - {i}.txt";

                using FileStream writer = new FileStream($"{fileName}", FileMode.Create);

                while (true)
                {
                    int readerLength = Math.Min(buffer.Length, filePart - totalWrite);
                    int currentRead = reader.Read(buffer, 0, readerLength);//vrushta kolko e uspql baita da prochete

                    if (currentRead == 0)
                    {
                        return;
                    }

                    writer.Write(buffer, 0, currentRead);
                    totalWrite += currentRead;

                    if (totalWrite >= filePart)
                    {
                        break;
                    }
                }

            }

        }
    }
}

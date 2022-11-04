using System;

namespace _3.__Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(new char[] { '\\', '.' });
            Console.WriteLine($"File name: {path[path.Length-2]}");
            Console.WriteLine($"File extension: {path[path.Length-1]}");

        }
    }
}

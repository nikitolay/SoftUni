using System;

namespace _4._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {

                PrintingTriangle(1, i);
            }
            for (int i = n+1; i >= 0; i--)
            {

                PrintingTriangle(1, i);
            }
        }

        private static void PrintingTriangle(int start, int end)
        {
            for (int i = start; i < end; i++)
            {

                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                string characters = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = characters[j];
                }
            }
            char @char = char.Parse(Console.ReadLine());
            bool isContains = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == @char)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isContains = true;
                        break;
                    }
                }
            }
            if (!isContains)
            {
                Console.WriteLine($"{@char} does not occur in the matrix");
            }
        }
    }
}

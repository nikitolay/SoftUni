using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }
            while (true)
            {

                string[] command = Console.ReadLine().Split();
                if (command[0] == "END")
                {
                    break;
                }

                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int rowFrom = int.Parse(command[1]);
                int colFrom = int.Parse(command[2]);
                int rowTo = int.Parse(command[3]);
                int colTo = int.Parse(command[4]);
                if (rowFrom < 0 || colFrom < 0 || rowTo < 0 || colTo < 0 || rowFrom >= matrix.GetLength(0) || colFrom >= matrix.GetLength(1) || rowTo >= matrix.GetLength(0) || colTo >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string first = matrix[rowFrom, colFrom];
                string second = matrix[rowTo, colTo];

                matrix[rowFrom, colFrom] = second;
                matrix[rowTo, colTo] = first;


                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}

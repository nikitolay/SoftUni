using System;
using System.Linq;

namespace _02._Garden
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] garden = new int[dimensions[0], dimensions[1]];

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                if (!IsInsise(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                garden[row, col]++;
                IncreaseLeft(garden, row, col);
                IncreaseRight(garden, row, col);
                IncreaseUp(garden, row, col);
                IncreaseDown(garden, row, col);
                command = Console.ReadLine();
            }
            PrintMatrix(garden);
        }

        private static void IncreaseDown(int[,] garden, int row, int col)
        {
            for (int i = row + 1; i < garden.GetLength(0); i++)
            {
                garden[i, col]++;
            }
        }

        private static void IncreaseUp(int[,] garden, int row, int col)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                garden[i, col]++;
            };
        }

        private static void IncreaseRight(int[,] garden, int row, int col)
        {
            for (int i = col + 1; i < garden.GetLength(1); i++)
            {
                garden[row, i]++;
            }
        }

        private static void IncreaseLeft(int[,] garden, int row, int col)
        {
            for (int i = col - 1; i >= 0; i--)
            {
                garden[row, i]++;
            }
        }

        private static void PrintMatrix(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInsise(int[,] garden, int row, int col)
        {
            if (row < 0 || row >= garden.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= garden.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}

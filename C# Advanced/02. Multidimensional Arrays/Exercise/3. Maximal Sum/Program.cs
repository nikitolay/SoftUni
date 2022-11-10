using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int sum = int.MinValue;
            int row = -1;
            int col = -1;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                     matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                      matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        row = i;
                        col = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[row, col]} {matrix[row, col + 1]} {matrix[row, col + 1 + 1]}");
            Console.WriteLine($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]} {matrix[row + 1, col + 1 + 1]}");
            Console.WriteLine($"{matrix[row + 1 + 1, col]} {matrix[row + 1 + 1, col + 1]} {matrix[row + 1 + 1, col + 1 + 1]}");
        }
    }
}

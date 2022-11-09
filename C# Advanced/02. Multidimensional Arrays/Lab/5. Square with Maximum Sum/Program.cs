using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int sum = int.MinValue;
            int[,] newMatrix = new int[2, 2];
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (i != matrix.GetLength(0))
                    {

                        int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                        if (currentSum > sum)
                        {
                            newMatrix[0, 0] = matrix[i, j];
                            newMatrix[0, 1] = matrix[i, j + 1];
                            newMatrix[1, 0] = matrix[i + 1, j];
                            newMatrix[1, 1] = matrix[i + 1, j + 1];
                            sum = currentSum;
                        }
                    }
                }
            }
            Console.WriteLine($"{newMatrix[0, 0]} {newMatrix[0, 1]}");
            Console.WriteLine($"{newMatrix[1, 0]} {newMatrix[1, 1]}");
            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                matrix[i] = numbers;

            }
            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                    for (int k = 0; k < matrix[i + 1].Length; k++)
                    {
                        matrix[i + 1][k] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                if (row < 0 || col < 0 || row >= n || col >= matrix[row].Length)
                {
                    continue;
                }
                int value = int.Parse(command[3]);

                switch (command[0])
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int length = matrix[i].Length;
                for (int j = 0; j < length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

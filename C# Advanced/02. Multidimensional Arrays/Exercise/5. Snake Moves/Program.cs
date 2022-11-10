using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            string snake = Console.ReadLine();
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[index++];
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[index++];
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

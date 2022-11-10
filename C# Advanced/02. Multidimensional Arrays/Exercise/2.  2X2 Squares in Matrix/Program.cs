using System;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] characters = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = characters[j];
                }
            }
            int count = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    bool isEquals = matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i - 1, j] && matrix[i, j] == matrix[i - 1, j + 1];
                    if (isEquals)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }
}

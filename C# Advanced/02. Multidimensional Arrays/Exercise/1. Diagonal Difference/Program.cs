using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sumOne = 0;
            int sumTwo = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
                sumOne += numbers[i];
                sumTwo += numbers[numbers.Length - i - 1];
            }
            Console.WriteLine(Math.Abs(sumOne - sumTwo));
        }
    }
}

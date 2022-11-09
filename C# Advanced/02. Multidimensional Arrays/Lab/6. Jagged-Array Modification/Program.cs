using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "END")
                {
                    break;
                }
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int number = int.Parse(commands[3]);
                if (row < 0 || col < 0 || row >= size || col >= size)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                switch (commands[0])
                {
                    case "Add":
                        matrix[row, col] += number;
                        break;
                    case "Subtract":
                        matrix[row, col] -= number;
                        break;
                }
            }
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

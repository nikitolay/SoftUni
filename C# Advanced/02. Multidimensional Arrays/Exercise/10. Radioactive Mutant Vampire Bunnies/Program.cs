using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = sizes[0];
            int col = sizes[1];
            char[,] matrix = new char[row, col];
            int[] array = FillMatrix(matrix);
            int playerRow = array[0];
            int playerCol = array[1];

            string coordinates = Console.ReadLine();
            bool win = false;
            for (int i = 0; i < coordinates.Length; i++)
            {
                char coordinat = coordinates[i];

                matrix[playerRow, playerCol] = '.';
                if (coordinat == 'U')
                {
                    if (!IsInside(matrix, playerRow - 1, playerCol))
                    {
                        win = true;
                    }
                    else
                    {

                        matrix[--playerRow, playerCol] = 'P';
                    }


                }
                else if (coordinat == 'D')
                {

                    if (!IsInside(matrix, playerRow + 1, playerCol))
                    {
                        win = true;
                    }
                    else
                    {

                        matrix[++playerRow, playerCol] = 'P';
                    }

                }
                else if (coordinat == 'L')
                {

                    if (!IsInside(matrix, playerRow, playerCol - 1))
                    {
                        win = true;
                    }
                    else
                    {

                        matrix[playerRow, --playerCol] = 'P';
                    }

                }
                else if (coordinat == 'R')
                {

                    if (!IsInside(matrix, playerRow, playerCol + 1))
                    {
                        win = true;
                    }
                    else
                    {

                        matrix[playerRow, ++playerCol] = 'P';
                    }

                }
                SetBunnies(matrix);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
                if (win)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }



            }
        }

        private static void SetBunnies(char[,] matrix)
        {
            List<int> bunnies = GetBunnies(matrix);
            while (bunnies.Any())
            {
                int bunnyRow = bunnies[0];
                int bunnyCol = bunnies[1];

                if (IsInside(matrix, bunnyRow, bunnyCol - 1))
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }
                if (IsInside(matrix, bunnyRow, bunnyCol + 1))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
                if (IsInside(matrix, bunnyRow - 1, bunnyCol))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
                if (IsInside(matrix, bunnyRow + 1, bunnyCol))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
                bunnies.RemoveAt(0);
                bunnies.RemoveAt(0);
            }

        }

        private static List<int> GetBunnies(char[,] matrix)
        {
            List<int> coordinates = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        coordinates.Add(i);
                        coordinates.Add(j);
                    }

                }
            }
            return coordinates;
        }

        private static bool IsInside(char[,] matrix, int v, int playerCol)
        {
            return v >= 0 && playerCol >= 0 && v < matrix.GetLength(0) && playerCol < matrix.GetLength(1);
        }

        private static bool IsBunny(char[,] matrix, int v, int playerCol)
        {
            return matrix[v, playerCol] == 'B' && IsInside(matrix, v, playerCol);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static int[] FillMatrix(char[,] matrix)
        {
            int[] arr = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string characters = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = characters[j];
                    if (matrix[i, j] == 'P')
                    {

                        arr[0] = i;
                        arr[1] = j;
                    }
                }
            }
            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            List<string> commands = Console.ReadLine().Split(' ').ToList();
            int minerRow = 0;
            int minerCol = 0;
            int coals = 0;
            for (int i = 0; i < size; i++)
            {
                char[] characters = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = characters[j];
                    if (matrix[i, j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    if (matrix[i, j] == 'c')
                    {
                        coals++;
                    }
                }
            }
            int currentCoal = 0;
            bool isFinished = false;
            while (commands.Any())
            {
                char[] currentResult = MoveIt(matrix, commands[0], ref minerRow, ref minerCol);
                if (commands[0] == "left")
                {

                }
                if (currentResult[0] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    isFinished = true;
                    break;
                }
                else if (currentResult[0] == 'c')
                {

                    currentCoal++;

                }
                if (currentCoal == coals)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    isFinished = true;
                    break;
                }




                commands.RemoveAt(0);
            }
            if (!isFinished)
            {
                Console.WriteLine($"{coals - currentCoal} coals left. ({minerRow}, {minerCol})");
            }

        }


        private static char[] MoveIt(char[,] matrix, string v, ref int minerRow, ref int minerCol)
        {
            char[] result = new char[matrix.GetLength(0)];
            if (v == "left" && IsInside(matrix, minerRow, minerCol - 1))
            {
                if (matrix[minerRow, minerCol - 1] == 'e')
                {
                    result[0] = 'e';
                }
                else
                {
                    if (matrix[minerRow, minerCol - 1] == 'c')
                    {
                        result[0] = 'c';
                    }
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow, minerCol - 1] = 's';
                }
                minerCol--;

            }
            else if (v == "right" && IsInside(matrix, minerRow, minerCol + 1))
            {
                if (matrix[minerRow, minerCol + 1] == 'e')
                {
                    result[0] = 'e';
                }
                else
                {
                    if (matrix[minerRow, minerCol + 1] == 'c')
                    {
                        result[0] = 'c';
                    }

                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow, minerCol + 1] = 's';
                }
                minerCol++;

            }
            else if (v == "up" && IsInside(matrix, minerRow - 1, minerCol))
            {
                if (matrix[minerRow - 1, minerCol] == 'e')
                {
                    result[0] = 'e'; ;
                }
                else
                {
                    if (matrix[minerRow - 1, minerCol] == 'c')
                    {
                        result[0] = 'c'; ;
                    }
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow - 1, minerCol] = 's';
                }
                minerRow--;


            }
            else if (v == "down" && IsInside(matrix, minerRow, minerCol))
            {
                if (matrix[minerRow + 1, minerCol] == 'e')
                {
                    result[0] = 'e';
                }
                else
                {
                    if (matrix[minerRow + 1, minerCol] == 'c')
                    {
                        result[0] = 'c';
                    }
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow + 1, minerCol] = 's';
                }
                minerRow++;

            }
            return result;
        }

        private static bool IsInside(char[,] matrix, int minerRow, int minerCol)
        {
            return minerRow < matrix.GetLength(0) && minerRow >= 0 && minerCol < matrix.GetLength(1) && minerCol >= 0;
        }
    }
}

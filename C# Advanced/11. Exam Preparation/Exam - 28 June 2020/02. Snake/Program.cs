using System;
using System.Linq;

namespace _02._Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    territory[i, j] = input[j];
                    if (input[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                }
            }
            //PrintMatrix(territory);
            int foods = 0;

            while (true)
            {
                territory[snakeRow, snakeCol] = '.';
                string input = Console.ReadLine();

                if (input == "up")
                {
                    snakeRow -= 1;
                }
                else if (input == "down")
                {
                    snakeRow += 1;

                }
                else if (input == "left")
                {
                    snakeCol -= 1;
                }
                else if (input == "right")
                {
                    snakeCol += 1;
                }
                if (!IsInside(snakeRow, snakeCol, territory))
                {
                    Console.WriteLine("Game over!");

                    break;
                }


                if (territory[snakeRow, snakeCol] == '*')
                {
                    foods++;
                    if (foods == 10)
                    {
                        territory[snakeRow, snakeCol] = 'S';
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                }
                if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (territory[i, j] == 'B')
                            {
                                snakeRow = i;
                                snakeCol = j;
                            }
                        }
                    }
                }
                territory[snakeRow, snakeCol] = 'S';
                //PrintMatrix(territory);
            }
            Console.WriteLine($"Food eaten: {foods}");

            PrintMatrix(territory);

        }

        private static void PrintMatrix(char[,] territory)
        {
            for (int i = 0; i < territory.GetLength(0); i++)
            {
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    Console.Write(territory[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int snakeRow, int snakeCol, char[,] territory)
        {
            if (snakeRow < 0 || snakeRow >= territory.GetLength(0))
            {
                return false;
            }
            else if (snakeCol < 0 || snakeCol >= territory.GetLength(1))
            {
                return false;

            }
            return true;
        }
    }
}

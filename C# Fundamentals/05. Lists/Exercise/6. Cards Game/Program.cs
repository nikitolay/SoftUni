using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> playerTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                if (playerOne[0] > playerTwo[0])
                {
                    playerOne.Add(playerOne[0]);
                    playerOne.Add(playerTwo[0]);
                }
                else if (playerOne[0] < playerTwo[0])
                {
                    playerTwo.Add(playerTwo[0]);
                    playerTwo.Add(playerOne[0]);
                }

                playerOne.Remove(playerOne[0]);
                playerTwo.Remove(playerTwo[0]);

                if (playerOne.Count == 0)
                {
                    int sum = playerTwo.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (playerTwo.Count == 0)
                {
                    int sum = playerOne.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}


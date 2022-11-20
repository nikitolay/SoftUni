using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                { "Datura Bombs",0},
                { "Cherry Bombs",0},
                { "Smoke Decoy Bombs",0},
            };

            while (effects.Any() && casings.Any())
            {
                if (bombs.All(x => x.Value >= 3))
                {
                    break;
                }
                bool isMakeBomb = false;
                int sum = effects.Peek() + casings.Peek();
                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                    isMakeBomb = true;
                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                    isMakeBomb = true;
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    isMakeBomb = true;
                }

                if (isMakeBomb)
                {
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {

                    int last = casings.Pop();
                    casings.Push(last - 5);
                }
            }
            if (casings.Any() && effects.Any())
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {

                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}

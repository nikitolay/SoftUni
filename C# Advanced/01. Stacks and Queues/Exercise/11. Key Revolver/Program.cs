using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));//kurshumi
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligence = int.Parse(Console.ReadLine());
            int bulletsCount = 0;
            while (locks.Any() && bullets.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();

                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bulletsCount++;
                if (bullets.Count >= 1 && bulletsCount % size == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count < 1)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletsCount * price)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

        }
    }
}

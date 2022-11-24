using _5._Birthday_Celebrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Food_Shortage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> peoples = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    if (peoples.Any(x => x.Name == citizen.Name))
                    {
                        continue;
                    }
                    else
                    {
                        peoples.Add(citizen);
                    }
                }
                else if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    if (peoples.Any(x => x.Name == rebel.Name))
                    {
                        continue;
                    }
                    else
                    {
                        peoples.Add(rebel);
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                IBuyer person = peoples.FirstOrDefault(x => x.Name == command);
                if (person != null)
                {
                    person.BuyFood();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(peoples.Sum(x => x.Food));
        }
    }
}

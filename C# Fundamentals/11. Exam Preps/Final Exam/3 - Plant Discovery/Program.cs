using System;
using System.Collections.Generic;
using System.Linq;

namespace _3___Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> plantRarity = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plant = input[0];
                int rarity = int.Parse(input[1]);
                if (plantRarity.ContainsKey(plant))
                {
                    plantRarity[plant][0] = rarity;
                }
                else
                {

                    plantRarity.Add(plant, new List<int>());
                    plantRarity[plant].Add(rarity);
                }

            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Exhibition")
                {
                    break;
                }
                switch (input[0])
                {
                    case "Rate":
                        if (plantRarity.ContainsKey(input[1]))
                        {

                            plantRarity[input[1]].Add(int.Parse(input[2]));
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        if (plantRarity.ContainsKey(input[1]))
                        {

                            plantRarity[input[1]][0] = int.Parse(input[2]);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        if (plantRarity.ContainsKey(input[1]))
                        {

                            int first = plantRarity[input[1]].First();
                            plantRarity[input[1]] = new List<int>() { first };
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plantRarity)
            {
                var average = item.Value.Count > 1 ? item.Value.Skip(1).Average() : 0;
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {average:f2}");
            }
        }
    }
}

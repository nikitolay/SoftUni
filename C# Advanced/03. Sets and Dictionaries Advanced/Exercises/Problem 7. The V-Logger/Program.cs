using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<List<string>>> dictionary = new Dictionary<string, List<List<string>>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Statistics")
                {
                    break;
                }
                if (input[1] == "joined")
                {
                    if (!dictionary.ContainsKey(input[0]))
                    {
                        dictionary.Add(input[0], new List<List<string>>());
                        dictionary[input[0]].Add(new List<string>());
                        dictionary[input[0]].Add(new List<string>());
                    }
                }
                else if (input[1] == "followed")
                {
                    if (dictionary.ContainsKey(input[0]) && dictionary.ContainsKey(input[2]))
                    {
                        if (input[0] != input[2])
                        {
                            if (!dictionary[input[0]][1].Contains(input[2]))
                            {

                                dictionary[input[0]][1].Add(input[2]);
                            }
                            if (!dictionary[input[2]][0].Contains(input[0]))
                            {

                                dictionary[input[2]][0].Add(input[0]);
                            }
                        }
                    }
                }

            }
            Console.WriteLine($"The V-Logger has a total of {dictionary.Count} vloggers in its logs.");
            int index = 1;
            foreach (var item in dictionary.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count))
            {
                Console.WriteLine($"{index}. {item.Key} : {item.Value[0].Count} followers, {item.Value[1].Count} following");
                if (index == 1)
                {
                    foreach (var follower in item.Value[0].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                index++;
            }
        }
    }
}

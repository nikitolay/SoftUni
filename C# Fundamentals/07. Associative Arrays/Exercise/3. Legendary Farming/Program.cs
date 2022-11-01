using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> junk = new Dictionary<string, int>();
            Dictionary<string, int> map2 = new Dictionary<string, int>()
            {
                { "shards",0},
                { "fragments",0},
                { "motes",0},
            };

            while (true)
            {
                List<string> list = Console.ReadLine().ToLower().Split().ToList();
                if (map2.ContainsKey(list[1]))
                {
                    map2[list[1]] += int.Parse(list[0]);
                    if (map2["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        map2["shards"] -= 250;
                        break;
                    }
                    else if (map2["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        map2["fragments"] -= 250;
                        break;
                    }
                    else if (map2["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        map2["motes"] -= 250;
                        break;
                    }
                }
                else
                {
                    if (junk.ContainsKey(list[1]))
                    {
                        junk[list[1]] += int.Parse(list[0]);
                    }
                    else
                    {

                        junk.Add(list[1], int.Parse(list[0]));
                    }
                }
                if (map2.ContainsKey(list[3]))
                {
                    map2[list[3]] += int.Parse(list[2]);
                    if (map2["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        map2["shards"] -= 250;
                        break;
                    }
                    else if (map2["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        map2["fragments"] -= 250;
                        break;
                    }
                    else if (map2["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        map2["motes"] -= 250;
                        break;
                    }
                }
                else
                {
                    if (junk.ContainsKey(list[3]))
                    {
                        junk[list[1]] += int.Parse(list[2]);
                    }
                    else
                    {

                        junk.Add(list[3], int.Parse(list[2]));
                    }
                }
                if (map2.ContainsKey(list[5]))
                {
                    map2[list[5]] += int.Parse(list[4]);
                    if (map2["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        map2["shards"] -= 250;
                        break;
                    }
                    else if (map2["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        map2["fragments"] -= 250;
                        break;
                    }
                    else if (map2["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        map2["motes"] -= 250;
                        break;
                    }

                }
                else
                {
                    if (junk.ContainsKey(list[5]))
                    {
                        junk[list[5]] += int.Parse(list[4]);
                    }
                    else
                    {

                        junk.Add(list[5], int.Parse(list[4]));
                    }
                }


                if (map2.ContainsKey(list[7]))
                {
                    map2[list[7]] += int.Parse(list[6]);
                    if (map2["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        map2["shards"] -= 250;
                        break;
                    }
                    else if (map2["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        map2["fragments"] -= 250;
                        break;
                    }
                    else if (map2["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        map2["motes"] -= 250;
                        break;
                    }

                }
                else
                {
                    if (junk.ContainsKey(list[7]))
                    {
                        junk[list[7]] += int.Parse(list[6]);
                    }
                    else
                    {

                        junk.Add(list[5], int.Parse(list[4]));
                    }
                }


            }
            foreach (var item in map2.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

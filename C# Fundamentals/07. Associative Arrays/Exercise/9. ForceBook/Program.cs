using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();


            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Lumpawaroo")
                {
                    break;
                }

                if (text.Contains("|"))
                {
                    List<string> list = text.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!dictionary.ContainsKey(list[0]))
                    {
                        dictionary.Add(list[0], new List<string>() { list[1] });
                    }
                    else
                    {
                        if (!dictionary[list[0]].Contains(list[1]))
                        {
                            dictionary[list[0]].Add(list[1]);
                        }
                    }
                }
                else if (text.Contains("->"))
                {
                    List<string> list = text.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (dictionary.Values.Any(x => x.Contains(list[0])))
                    {
                        var temp = dictionary.Values.FirstOrDefault(x => x.Contains(list[0]));
                        temp.Remove(list[0]);
                        dictionary[list[1]].Add(list[0]);

                    }
                    else
                    {
                        // dictionary.Add(list[1], new List<string>() { list[0] });
                        if (!dictionary.ContainsKey(list[1]))
                        {
                            dictionary.Add(list[1], new List<string>() { list[0] });
                            Console.WriteLine($"{list[0]} joins the {list[1]} side!");

                        }
                        else
                        {
                            dictionary[list[1]].Add(list[0]);
                            Console.WriteLine($"{list[0]} joins the {list[1]} side!");

                        }
                    }
                }


            }

            foreach (var item in dictionary.OrderByDescending(x => x.Value.Count).Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var e in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {e}");
                }
            }
        }


    }
}


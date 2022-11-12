using System;
using System.Collections.Generic;

namespace Problem_6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.None);
                if (!dictionary.ContainsKey(input[0]))
                {
                    dictionary.Add(input[0], new Dictionary<string, int>());
                }
                for (int j = 1; j < input.Length; j++)
                {
                    if (!dictionary[input[0]].ContainsKey(input[j]))
                    {
                        dictionary[input[0]].Add(input[j], 1);
                    }
                    else
                    {
                        dictionary[input[0]][input[j]]++;

                    }
                }
            }
            string[] command = Console.ReadLine().Split();
            string found = "";
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var element in item.Value)
                {

                    if (item.Key == command[0] && element.Key == command[1])
                    {
                        found = " (found!)";
                    }
                    Console.WriteLine($"* {element.Key} - {element.Value}{found}");
                    found = string.Empty;
                }
            }
        }
    }
}

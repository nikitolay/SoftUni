using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (dict.ContainsKey(list[i][j]))
                    {
                        dict[list[i][j]]++;
                    }
                    else
                    {
                        dict.Add(list[i][j], 1);
                    }
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}

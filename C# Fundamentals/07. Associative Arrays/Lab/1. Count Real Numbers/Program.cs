using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (map.ContainsKey(list[i]))
                {
                    map[list[i]]++;
                }
                else
                {
                    map.Add(list[i], 1);
                }
            }
            foreach (var i in map)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}

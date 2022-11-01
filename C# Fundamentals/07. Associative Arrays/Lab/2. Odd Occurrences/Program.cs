using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().ToLower().Split().ToList();
            Dictionary<string, int> map = new Dictionary<string, int>();
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
            foreach (var item in map.Where(x => x.Value % 2 != 0))
            {
                Console.Write(item.Key + " ");
            }
        }
    }
}

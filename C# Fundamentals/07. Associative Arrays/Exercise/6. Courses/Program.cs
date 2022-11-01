using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _6._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            while (true)
            {
                List<string> list = Console.ReadLine().Split(" : ").ToList();
                if (list[0] == "end")
                {
                    break;
                }
                if (!dic.ContainsKey(list[0]))
                {
                    dic.Add(list[0], new List<string>() { list[1] });
                }
                else
                {
                    dic[list[0]].Add(list[1]);
                }
            }
            foreach (var item in dic.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var el in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {el}");
                }
            }
        }
    }
}

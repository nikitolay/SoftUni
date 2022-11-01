using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            while (true)
            {
                List<string> list = Console.ReadLine().Split(" -> ").ToList();
                if (list[0] == "End")
                {
                    break;
                }
                string company = list[0];
                string employeeId = list[1];
                if (!map.ContainsKey(company))
                {
                    map.Add(company, new List<string>() { employeeId });
                }
                if (!map[company].Contains(employeeId))
                {
                    map[company].Add(employeeId);
                }
            }
            foreach (var item in map.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var el in item.Value)
                {
                    Console.WriteLine($"-- {el}");
                }
            }
        }
    }
}

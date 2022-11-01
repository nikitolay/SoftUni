using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.__Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> academy = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string list = Console.ReadLine();
                if (!academy.ContainsKey(list))
                {
                    decimal grade = decimal.Parse(Console.ReadLine());

                    academy.Add(list, new List<decimal>() { grade });
                }
                else
                {
                    academy[list].Add(decimal.Parse(Console.ReadLine()));
                }
            }
            foreach (var item in academy.OrderByDescending(x => x.Value.Average()).Where(x => x.Value.Average() >= 4.50m))
            {

                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");

            }
        }
    }
}

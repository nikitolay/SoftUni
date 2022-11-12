using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (!students.ContainsKey(data[0]))
                {
                    students.Add(data[0], new List<decimal>());
                }

                students[data[0]].Add(decimal.Parse(data[1]));

            }
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(x => x.ToString("F2")))} (avg: {item.Value.Average().ToString("F2")})");
            }
        }
    }
}

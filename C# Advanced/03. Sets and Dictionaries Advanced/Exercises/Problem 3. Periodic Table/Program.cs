using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> compounds = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    compounds.Add(input[j]);
                }
            }
            Console.WriteLine(string.Join(" ", compounds.OrderBy(x => x)));
        }
    }
}

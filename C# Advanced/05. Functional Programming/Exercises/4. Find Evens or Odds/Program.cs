using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string type = Console.ReadLine();
            Predicate<int> evenOrOds;
            List<int> nums = new List<int>();
            if (type == "odd")
            {
                evenOrOds = x => x % 2 != 0;
            }
            else
            {
                evenOrOds = x => x % 2 == 0;

            }
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {

                nums.Add(i);

            }
            Console.WriteLine(string.Join(" ", nums.Where(x => evenOrOds(x))));
        }
    }
}

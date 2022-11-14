using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x=>x%2==0)
                .OrderBy(x=>x)
                .ToArray();
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}

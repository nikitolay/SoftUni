using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            Action<List<string>> Print = input => input.ForEach(x => Console.WriteLine($"Sir {x}"));
            Print(names);
        }
    }
}

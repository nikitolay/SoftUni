using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console
                .ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x += x * 0.20)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}

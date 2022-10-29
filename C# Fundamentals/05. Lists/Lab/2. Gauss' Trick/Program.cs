using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < list.Count / 2; i++)
            {
                list[i] += list[list.Count - 1 - i];
            }
            Console.WriteLine(String.Join(" ", list.Take(list.Count - list.Count / 2)));
        }
    }
}

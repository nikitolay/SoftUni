using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
            for (int i = 0; i < 3; i++)
            {
                Console.Write(list[i] + " ");
            }
        }
    }
}

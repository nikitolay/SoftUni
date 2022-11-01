using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            foreach (var item in list.Where(x => x.Length % 2 == 0))
            {
                Console.WriteLine(item);
            }
        }
    }
}

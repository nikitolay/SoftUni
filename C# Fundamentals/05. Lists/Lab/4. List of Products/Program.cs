using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            int number = 1;
            foreach (var item in list.OrderBy(x => x))
            {
                Console.WriteLine($"{number++}.{item}");
            }
        }
    }
}

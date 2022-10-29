using System;
using System.Collections.Generic;

namespace _5._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            TotalPrice(product, n);
        }

        private static void TotalPrice(string product, int n)
        {
            Dictionary<string, decimal> price = new Dictionary<string, decimal>()
            {
                { "coffee",1.50m},
                {"water",1.00m},
                {"coke",1.40m},
                {"snacks",2.00m},

            };
            Console.WriteLine(price[product] * n);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> map = new Dictionary<string, decimal>();
            Dictionary<string, decimal> quantitty = new Dictionary<string, decimal>();
            decimal oldPrice = 0;
            while (true)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr[0] == "buy")
                {
                    break;
                }
                string productName = arr[0];
                decimal price = decimal.Parse(arr[1]);
                decimal quantity = decimal.Parse(arr[2]);

                if (map.ContainsKey(productName))
                {
                    if (map[productName] != price)
                    {

                        map[productName] = price;
                    }
                    quantitty[productName] += quantity;
                }
                else
                {
                    map.Add(productName, price);
                    quantitty.Add(productName, quantity);
                }
            }
            foreach (var e in quantitty)
            {
                foreach (var item in map)
                {
                    if (item.Key == e.Key)
                    {

                        Console.WriteLine($"{item.Key} -> {item.Value * e.Value}");
                    }

                }
            }
        }
    }
}

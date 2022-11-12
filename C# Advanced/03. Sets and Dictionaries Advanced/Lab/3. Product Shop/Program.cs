using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProductPrice = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");
                if (input[0] == "Revision")
                {
                    break;
                }
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if (!shopProductPrice.ContainsKey(shop))
                {
                    shopProductPrice.Add(shop, new Dictionary<string, double>());
                }
                if (!shopProductPrice[shop].ContainsKey(product))
                {
                    shopProductPrice[shop].Add(product, price);

                }
            }
            foreach (var item in shopProductPrice.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var element in item.Value)
                {
                    Console.WriteLine($"Product: {element.Key}, Price: {element.Value}");
                }
            }
        }
    }
}

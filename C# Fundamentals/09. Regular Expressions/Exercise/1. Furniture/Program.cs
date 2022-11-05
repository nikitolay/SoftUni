using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;
            List<string> boughtProducts = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                Match matches = Regex.Match(input, @">>(?<name>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)", RegexOptions.IgnoreCase);
                if (matches.Success)
                {

                    boughtProducts.Add(matches.Groups["name"].Value);
                    totalSum += double.Parse(matches.Groups["price"].Value) * int.Parse(matches.Groups["quantity"].Value);
                }


            }
            Console.WriteLine("Bought furniture:");
            boughtProducts.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }
                Match matches = Regex.Match(input, @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+[.]?[\d]+)\$");
                if (matches.Success)
                {
                    string customer = matches.Groups["customer"].Value;
                    string product = matches.Groups["product"].Value;
                    int count = int.Parse(matches.Groups["count"].Value);
                    double price = double.Parse(matches.Groups["price"].Value);
                    Console.WriteLine($"{customer}: {product} - {count * price:f2}");
                    total += count * price;
                }
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}

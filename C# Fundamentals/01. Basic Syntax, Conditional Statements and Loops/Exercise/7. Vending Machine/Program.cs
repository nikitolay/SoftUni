using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] coins = new double[] { 0.1, 0.2, 0.5, 1, 2 };
            Dictionary<string, double> map = new Dictionary<string, double>()
            {
                {"Nuts",2.0 },
                {"Water",0.7 },
                {"Crisps",1.5 },
                {"Soda",0.8 },
                {"Coke",1.0 },
            };
            double currentCoins = 0;
            string command = Console.ReadLine();
            while (command != "Start")
            {
                double coin = double.Parse(command);
                if (coins.Contains(coin))
                {
                    currentCoins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                command = Console.ReadLine();
            }
            string product = Console.ReadLine();
            while (product != "End")
            {
                if (map.ContainsKey(product))
                {
                    if (currentCoins - map[product]>=0)
                    {

                    currentCoins -= map[product];
                        Console.WriteLine($"Purchased {product}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }


                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {currentCoins:f2}");
        }
    }
}


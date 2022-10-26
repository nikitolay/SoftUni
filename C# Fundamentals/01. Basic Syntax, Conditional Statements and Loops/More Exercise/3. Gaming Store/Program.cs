using System;
using System.Collections.Generic;
using System.Globalization;

namespace _3._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> dictionary = new Dictionary<string, double>()
           {
               { "OutFall 4",39.99},
               { "CS: OG",15.99},
               { "Zplinter Zell",19.99},
               { "Honored 2",59.99},
               { "RoverWatch",29.99},
               { "RoverWatch Origins Edition",39.99},
           };

            double currentBalance = double.Parse(Console.ReadLine());
            double balance = currentBalance;
            string command = Console.ReadLine();
            while (command != "Game Time")
            {
                if (currentBalance<=0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                if (dictionary.ContainsKey(command))
                {
                    if (currentBalance-dictionary[command]<0)
                    {
                        Console.WriteLine("Too Expensive");

                    }
                    else
                    {
                        currentBalance-=dictionary[command];
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }


                command = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${balance- currentBalance:f2}. Remaining: ${balance-(balance - currentBalance):f2}");
        }
    }
}

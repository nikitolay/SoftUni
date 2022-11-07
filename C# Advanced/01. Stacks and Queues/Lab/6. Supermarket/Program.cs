using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join("\n", names));
                    names.Clear();
                    continue;
                }
                if (input == "End")
                {
                    break;
                }

                names.Enqueue(input);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}

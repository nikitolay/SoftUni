using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                guests.Add(input);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                guests.Remove(input);
            }
            Console.WriteLine(guests.Count());


            foreach (string input in guests.Where(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(input);
            }
            foreach (string input in guests.Where(x => char.IsLetter(x[0])))
            {
                Console.WriteLine(input);
            }
        }
    }
}

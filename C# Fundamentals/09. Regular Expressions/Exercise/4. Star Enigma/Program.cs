using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());
            string regex = @"@(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[A,D])![^@\-!:>]*->(?<count>[\d]+)";
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < linesNumber; i++)
            {
                string messages = Console.ReadLine();
                int sum = messages.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');
                string decryptedMessage = "";
                foreach (char charType in messages)
                {
                    decryptedMessage += (char)(charType - sum);
                }
                Match matches = Regex.Match(decryptedMessage, regex, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    char type = char.Parse(matches.Groups["type"].Value);

                    if (type == 'A')
                    {
                        attacked.Add(name);
                    }
                    else
                    {
                        destroyed.Add(name);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            attacked.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine($"-> {x}"));
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            destroyed.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine($"-> {x}"));

        }
    }
}

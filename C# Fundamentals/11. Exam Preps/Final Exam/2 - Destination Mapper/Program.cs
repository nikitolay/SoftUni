using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2___Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, @"([=\/])(?<place>[A-Z][A-z]{2,})\1");
            int points = 0;
            List<string> list = new List<string>();
            foreach (Match item in matches)
            {
                list.Add(item.Groups["place"].Value);
                points += item.Groups["place"].Value.Trim().Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}

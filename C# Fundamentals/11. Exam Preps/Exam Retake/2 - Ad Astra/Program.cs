using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2___Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, @"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1");
            int days = 0;
            int totalCalories = 0;
            foreach (Match item in matches)
            {
                totalCalories += int.Parse(item.Groups["calories"].Value);
            }
            days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["name"]}, Best before: {item.Groups["date"]}, Nutrition: {item.Groups["calories"]}");
            }
        }
    }
}

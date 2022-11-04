using System;
using System.Text.RegularExpressions;

namespace _3._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //don't work in c#??????
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"\b(?<day>[\d]{2})([-\/.])(?<month>[A-Z][a-z]{2})\2(?<year>[0-9]{4})\b");
            foreach (Match item in matches)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}

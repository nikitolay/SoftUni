using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b");

            var phoneMatches = matches.Cast<Match>().Select(a => a.Value.Trim()).ToList();
            Console.WriteLine(String.Join(", ", phoneMatches));
        }
    }
}

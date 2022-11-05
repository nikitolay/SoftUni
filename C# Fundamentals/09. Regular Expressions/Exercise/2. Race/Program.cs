using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var patternForName = new Regex(@"(?<name>[A-Za-z]+)");
            var patternForDigit = new Regex(@"(?<digits>\d+)");
            var sumOfDigits = 0;

            var participant = new Dictionary<string, int>();

            var names = Console.ReadLine().Split(", ").ToList();

            var input = Console.ReadLine();

            while (input != "end of race")
            {
                var matchedNames = patternForName.Matches(input);
                var matchedDigits = patternForDigit.Matches(input);
                var currentName = string.Join("", matchedNames);
                var currentDigit = string.Join("", matchedDigits);

                sumOfDigits = 0;

                for (int i = 0; i < currentDigit.Length; i++)
                {
                    sumOfDigits += int.Parse(currentDigit[i].ToString());
                }

                if (names.Contains(currentName))
                {
                    if (!participant.ContainsKey(currentName))
                    {
                        participant.Add(currentName, sumOfDigits);
                    }
                    else
                    {
                        participant[currentName] += sumOfDigits;
                    }
                }


                input = Console.ReadLine();
            }
            var winners = participant.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }
            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }
            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
        }
    }
}

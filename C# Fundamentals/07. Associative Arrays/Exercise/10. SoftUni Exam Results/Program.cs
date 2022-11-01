using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languageMeetings = new Dictionary<string, int>();
            Dictionary<string, int> usernameWithPoints = new Dictionary<string, int>();
            while (true)
            {
                List<string> list = Console.ReadLine().Split("-").ToList();
                if (list[0] == "exam finished")
                {
                    break;
                }
                if (list[1] == "banned")
                {
                    usernameWithPoints.Remove(list[0]);
                    continue;
                }
                string username = list[0];
                string language = list[1];
                int points = int.Parse(list[2]);
                if (usernameWithPoints.ContainsKey(username))
                {
                    usernameWithPoints[username] = points;
                }
                else
                {

                    usernameWithPoints.Add(username, points);
                }
                if (languageMeetings.ContainsKey(language))
                {
                    languageMeetings[language]++;
                }
                else
                {
                    languageMeetings.Add(language, 1);

                }
            }
            Console.WriteLine("Results:");
            foreach (var item in usernameWithPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in languageMeetings.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} – {item.Value}");
            }
        }
    }
}

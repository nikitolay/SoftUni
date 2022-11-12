using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> usernameContestPoints = new SortedDictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();


            while (true)
            {
                string[] input = Console.ReadLine().Split(":");
                if (input[0] == "end of contests")
                {
                    break;
                }
                string contest = input[0];
                string password = input[1];
                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword.Add(contest, password);
                }
            }
            while (true)
            {
                string[] input = Console.ReadLine().Split("=>");
                if (input[0] == "end of submissions")
                {
                    break;
                }
                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);
                if (contestPassword.ContainsKey(contest))
                {
                    if (contestPassword[contest] == password)
                    {


                        if (!usernameContestPoints.ContainsKey(username))
                        {
                            usernameContestPoints.Add(username, new Dictionary<string, int>());
                        }
                        if (!usernameContestPoints[username].ContainsKey(contest))
                        {
                            usernameContestPoints[username].Add(contest, points);
                        }
                        else
                        {
                            if (points > usernameContestPoints[username][contest])
                            {

                                usernameContestPoints[username][contest] = points;
                            }

                        }
                    }

                }
            }
            SortedDictionary<int, string> total = new SortedDictionary<int, string>();
            foreach (var user in usernameContestPoints)
            {
                int userTotalPoints = user.Value.Sum(x => x.Value);
                total.Add(userTotalPoints, user.Key);
            }


            string bestUser = total.Reverse().Take(1).Select(x => x.Value).First();
            int bestPoints = total.Reverse().Take(1).Select(x => x.Key).First();
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in usernameContestPoints)
            {
                Console.WriteLine(item.Key);
                foreach (var element in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {element.Key} -> {element.Value}");
                }
            }
        }
    }
}

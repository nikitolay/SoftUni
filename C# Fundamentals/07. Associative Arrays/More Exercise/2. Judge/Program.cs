using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Dictionary<string, Dictionary<string, int>> contestUsernamePoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> userTotalPoints = new Dictionary<string, int>();
            while (true)
            {
                List<string> list = Console.ReadLine().Split(" -> ").ToList();
                if (list[0] == "no more time")
                {
                    break;
                }
                string username = list[0];
                string contest = list[1];
                int points = int.Parse(list[2]);

                if (contestUsernamePoints.ContainsKey(contest))
                {
                    if (contestUsernamePoints[contest].ContainsKey(username))
                    {
                        if (userTotalPoints.ContainsKey(username))
                        {
                            if (userTotalPoints[username] < points)
                            {
                                contestUsernamePoints[contest][username] = points;
                                userTotalPoints[username] = points;
                            }
                        }
                    }
                    else
                    {
                        contestUsernamePoints[contest].Add(username, points);
                        if (userTotalPoints.ContainsKey(username))
                        {
                            userTotalPoints[username] += points;
                        }
                        else
                        {
                            userTotalPoints.Add(username, points);
                        }
                    }
                }
                else
                {
                    contestUsernamePoints.Add(contest, new Dictionary<string, int>());
                    contestUsernamePoints[contest].Add(username, points);
                    if (userTotalPoints.ContainsKey(username))
                    {
                        userTotalPoints[username] += points;
                    }
                    else
                    {
                        userTotalPoints.Add(username, points);
                    }

                }



            }

            foreach (var item in contestUsernamePoints)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Count} participants");

                int index = 1;
                foreach (var e in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ThenBy(x => x))
                {
                    Console.WriteLine($"{index++}. {e.Key} <::> {e.Value}");
                }
            }

            int indexx = 1;
            Console.WriteLine("Individual standings:");
            foreach (var item in userTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{indexx++}. {item.Key} -> {item.Value}");
            }


        }
    }
}

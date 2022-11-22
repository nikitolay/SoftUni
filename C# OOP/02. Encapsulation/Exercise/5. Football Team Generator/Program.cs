using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Football_Team_Generator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string[] info = Console.ReadLine().Split(';');
                try
                {


                    if (info[0] == "END")
                    {
                        break;
                    }
                    if (info[0] == "Team")
                    {
                        teams.Add(new Team(info[1]));
                    }
                    else if (info[0] == "Add")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == info[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {info[1]} does not exist.");
                        }
                        Player player = new Player(info[2], int.Parse(info[3]), int.Parse(info[4]), int.Parse(info[5]), int.Parse(info[6]), int.Parse(info[7]));
                        team.Add(player);
                    }
                    else if (info[0] == "Remove")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == info[1]);
                        team.Remove(info[2]);
                    }
                    else if (info[0] == "Rating")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == info[1]);
                        Console.WriteLine(team);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}

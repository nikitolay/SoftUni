using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int countOfTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] arr = Console.ReadLine().Split("-");
                Team team = new Team(arr[1]);
                team.Creator = arr[0];
                if (teams.Any(x => x.Name == arr[1]))
                {
                    Console.WriteLine($"Team {arr[1]} was already created!");
                    continue;
                }
                Console.WriteLine($"Team {arr[1]} has been created by {team.Creator}!");
                teams.Add(team);
            }
            while (true)
            {
                string array = Console.ReadLine();
                if (array == "end of assignment")
                {

                    break;
                }
                List<string> list = array.Split("->").ToList();
                if (teams.Any(x => x.Creator == list[0] && x.Name != list[1]))
                {
                    Console.WriteLine($"{list[0]} cannot create another team!");
                    continue;
                }
                if (!teams.Any(x => x.Name == list[1]))
                {
                    Console.WriteLine($"Team {list[1]} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.Users.Contains(list[0]) || x.Creator == list[0]))
                {
                    Console.WriteLine($"Member {list[0]} cannot join team {list[1]}!");
                    continue;
                }
                if (teams.Any(x => x.Creator == list[0] && x.Name != list[1]))
                {
                    Console.WriteLine($"Team {list[1]} was already created!");
                    continue;
                }
                Team team = teams.Where(x => x.Name == list[1]).First();
                team.Users.Add(list[0]);
            }

            foreach (var item in teams.Where(x => x.Users.Count > 0).OrderByDescending(x => x.Users.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"- {item.Creator}");
                foreach (var user in item.Users)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var item in teams.Where(x => x.Users.Count == 0))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
    public class Team
    {

        public Team(string name)
        {
            Users = new List<string>();
            Name = name;
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Users { get; set; }
    }

}

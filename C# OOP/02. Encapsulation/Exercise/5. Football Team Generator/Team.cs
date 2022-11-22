using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Football_Team_Generator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public void Add(Player player) => players.Add(player);
        public void Remove(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (!players.Contains(player))
            {
                throw new ArgumentException($"Player {name} is not in {Name} team.");
            }
            players.Remove(player);
        }

        public int Raiting => (int)players.Average(x => x.SkillLevel);

        public override string ToString()
        {
            string result = players.Count > 0 ? Raiting.ToString() : "0";
            return $"{Name} - {result}";
        }
    }
}

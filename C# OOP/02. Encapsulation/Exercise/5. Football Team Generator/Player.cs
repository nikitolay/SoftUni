using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Football_Team_Generator
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.name = name;
            this.stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                }
                name = value;
            }
        }

        public int SkillLevel => (stats.Endurance + stats.Dribble + stats.Passing + stats.Sprint + stats.Shooting) / 5;
    }
}

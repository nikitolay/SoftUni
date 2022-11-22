using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Football_Team_Generator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                endurance = value;
            }
        }


        public int Sprint
        {
            get { return sprint; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                sprint = value;
            }
        }


        public int Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                dribble = value;
            }
        }


        public int Passing
        {
            get { return passing; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                passing = value;
            }
        }


        public int Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                shooting = value;
            }
        }

    }
}

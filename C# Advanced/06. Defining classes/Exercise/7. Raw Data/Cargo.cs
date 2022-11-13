using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }
}

using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite
{
    public class Repair : IRepair
    {
        public Repair(string name, int workedHours)
        {
            Name = name;
            WorkedHours = workedHours;
        }

        public string Name { get; set; }
        public int WorkedHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {WorkedHours}";
        }
    }
}

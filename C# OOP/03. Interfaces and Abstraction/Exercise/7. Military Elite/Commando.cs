using _7._Military_Elite.Enumerations;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _7._Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMissions> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public ICollection<IMissions> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Missions:");
            foreach (var m in Missions)
            {
                sb.AppendLine("  " + m.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

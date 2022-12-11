using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {

        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }
        public double MilitaryPower
        {
            get
            {

                double totalAmount = army.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel);
                if (army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    totalAmount *= 1.30;
                }
               else if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    totalAmount *= 1.45;
                }
                return Math.Round(totalAmount, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons;

        public void AddUnit(IMilitaryUnit unit)
                 => army.Add(unit);

        public void AddWeapon(IWeapon weapon)
                 => weapons.Add(weapon);

        public string PlanetInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Planet: {Name}");
            result.AppendLine($"--Budget: {Budget} billion QUID");
            string units = Army.Count > 0 ? string.Join(", ", Army) : "No units";
            result.AppendLine($"--Forces: {units}");
            string weapons = Weapons.Count > 0 ? string.Join(", ", Weapons) : "No weapons";

            result.AppendLine($"--Combat equipment: {weapons}");
            result.AppendLine($"--Military Power: {MilitaryPower}");

            return result.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var force in Army)
            {
                force.IncreaseEndurance();
            }

        }
    }
}

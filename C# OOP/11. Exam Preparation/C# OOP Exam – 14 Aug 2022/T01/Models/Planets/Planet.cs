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
        private double militaryPower;

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
            get { return CalculateMilitaryPower(militaryPower); }
            private set
            {
                double totalAmount = army.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel);
                if (army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    totalAmount *= 1.30;
                }
                if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    totalAmount *= 1.45;
                }
                militaryPower = value;
            }

        }
        private double CalculateMilitaryPower(double militaryPower)
        {
            return Math.Round(militaryPower, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons;

        public void AddUnit(IMilitaryUnit unit)
                 => army.Add(unit);

        public void AddWeapon(IWeapon weapon)
                 => weapons.Add(weapon);

        public string PlanetInfo()
        {
            throw new NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new NotImplementedException();
        }

        public void TrainArmy()
        {
            foreach (var force in army)
            {
                force.EnduranceLevel=5;
            }
        }
    }
}

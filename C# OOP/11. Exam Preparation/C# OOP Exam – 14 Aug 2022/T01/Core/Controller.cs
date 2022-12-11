using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            IMilitaryUnit militaryUnit;
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();

            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();

            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == militaryUnit.GetType().Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            planet.AddUnit(militaryUnit);
            planet.Spend(militaryUnit.Cost);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            IWeapon weapon;
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);

            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);

            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Contains(weapon))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);
            if (planets.Models.Contains(planet))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x=>x.Name))
            {
                result.AppendLine(planet.PlanetInfo());
            }
            return result.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            double firstMilitaryPower = firstPlanet.MilitaryPower;
            double secondMilitaryPower = secondPlanet.MilitaryPower;
            IPlanet winner = null;
            IPlanet loser = null;
            double budgetLoser = 0;

            //firstPlanet.Spend(firstPlanet.Budget / 2);
            //secondPlanet.Spend(secondPlanet.Budget / 2);
            if (firstMilitaryPower == secondMilitaryPower)
            {
                bool firstWin = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
                bool secondWin = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
                if (firstWin)
                {
                    winner = firstPlanet;

                    loser = secondPlanet;
                }
                else if (secondWin)
                {
                    winner = secondPlanet;

                    loser = firstPlanet;

                }
                else if (firstWin && secondWin || !firstWin && !secondWin)
                {
                    return OutputMessages.NoWinner;
                }
            }
            else if (firstMilitaryPower > secondMilitaryPower)
            {
                winner = firstPlanet;
                loser = secondPlanet;
            }
            else
            {
                winner = secondPlanet;
                loser = firstPlanet;
            }
            budgetLoser += loser.Budget / 2;


            winner.Spend(winner.Budget / 2);


            winner.Profit(budgetLoser);
            winner.Profit(loser.Army.Sum(x => x.Cost) + loser.Weapons.Sum(x => x.Price));
            planets.RemoveItem(loser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            foreach (var force in planet.Army)
            {
                force.IncreaseEndurance();
            }
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}

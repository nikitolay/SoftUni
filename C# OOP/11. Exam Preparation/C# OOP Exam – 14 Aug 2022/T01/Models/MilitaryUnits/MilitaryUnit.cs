using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int InitialValueOfEnduranceLevel = 1;
        public double Cost { get; }

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = InitialValueOfEnduranceLevel;
        }

        public int EnduranceLevel { get; protected set; }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}";
        }
    }
}

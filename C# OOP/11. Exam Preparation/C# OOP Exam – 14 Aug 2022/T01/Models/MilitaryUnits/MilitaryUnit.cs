﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int InitialValueEnduranceLevel = 1;
        public double Cost { get; }

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = InitialValueEnduranceLevel;
        }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}

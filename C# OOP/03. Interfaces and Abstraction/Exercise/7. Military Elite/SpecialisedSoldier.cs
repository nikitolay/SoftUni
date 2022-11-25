using _7._Military_Elite.Enumerations;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName,decimal salary,Corps corps) 
            : base(id, firstName, lastName,salary)
        {
            Corps= corps;
        }

        public Corps Corps { get; set ; }
    }
}

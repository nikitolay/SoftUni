using _7._Military_Elite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Interfaces
{
    public interface ISpecialisedSoldier:IPrivate
    {
        public Corps Corps { get; set; }
    }
}

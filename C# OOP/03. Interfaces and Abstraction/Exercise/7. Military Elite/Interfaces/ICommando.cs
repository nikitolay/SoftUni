using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Interfaces
{
    public interface ICommando:ISpecialisedSoldier
    {
        public ICollection<IMissions> Missions { get; set; }
    }
}

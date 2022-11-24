using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Interfaces
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; set; }
    }
}

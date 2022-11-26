using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public abstract class Creator
    {
        public abstract BaseHero CreateHero(string type, string name);
    }
}

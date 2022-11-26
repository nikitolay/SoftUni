﻿using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Power { get; set; }
        public abstract string CastAbility();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Birthday_Celebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}

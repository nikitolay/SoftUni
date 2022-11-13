using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Tire
    {
        public Tire( double pressure,int age)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}

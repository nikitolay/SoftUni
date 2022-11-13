using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Car_Salesman
{
    internal class Engine
    {
        public Engine(string model, int power, int displacement=0, string efficiency="")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }//
        public string Efficiency { get; set; }//
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
        public override string ToString()
        {
            return $"{Model}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace T02.Vehicles_Extension
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public double AirConditioner { get; set; }

        public abstract void Drive(double distance);
        public abstract void ReFuel(double fuel);
    }
}

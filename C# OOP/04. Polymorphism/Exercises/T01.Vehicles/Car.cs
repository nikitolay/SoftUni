using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Car : IVehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public virtual void Drive(double distance)
        {
            if (distance * (FuelConsumption+0.9) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption+0.9) * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public void ReFuel(double fuel)
        {
            FuelQuantity += fuel;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Truck : IVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {

            if (distance * (FuelConsumption + 1.6) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption + 1.6) * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void ReFuel(double fuel)
        {
            FuelQuantity += fuel * 0.95;
        }
    }
}

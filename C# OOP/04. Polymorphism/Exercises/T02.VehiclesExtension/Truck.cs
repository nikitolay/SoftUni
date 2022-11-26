using System;
using System.Collections.Generic;
using System.Text;

namespace T02.Vehicles_Extension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            AirConditioner = 1.6;
            FuelQuantity = FuelCheck(fuelQuantity);

        }
        private double FuelCheck(double fuelQuantity)
        {
            if (fuelQuantity > TankCapacity)
            {
                return 0;
            }
            return fuelQuantity;
        }

        public override void Drive(double distance)
        {

            if (distance * (FuelConsumption + AirConditioner) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption + AirConditioner) * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }


        public override void ReFuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuel * 0.95;

            }
        }


    }
}

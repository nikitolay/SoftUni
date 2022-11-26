using System;
using System.Collections.Generic;
using System.Text;

namespace T02.Vehicles_Extension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            AirConditioner = 1.4;
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
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            if (distance * (FuelConsumption) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption) * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
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
                FuelQuantity += fuel;

            }
        }
    }
}

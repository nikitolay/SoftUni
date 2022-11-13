using System;
using System.Collections.Generic;
using System.Text;

namespace _6._Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelConsumptionPerKilometer;
        private double fuelAmount;
        private double travelledDistance;

        public Car(string model, double fuelConsumptionPerKilometer, double fuelAmount)
        {
            this.model = model;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.fuelAmount = fuelAmount;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }


        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public void CanMove(double amountKm)
        {
            if (fuelConsumptionPerKilometer * amountKm > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                fuelAmount -= FuelConsumptionPerKilometer*amountKm;
                travelledDistance += amountKm;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                if (cars.Any(x => x.Model == arr[0]))
                {
                    continue;
                }
                Car car = new Car(arr[0], double.Parse(arr[1]), double.Parse(arr[2]));
                cars.Add(car);
            }
            while (true)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr[0] == "End")
                {
                    break;
                }
                Car car = cars.FirstOrDefault(x => x.Model == arr[1]);
                if (!car.TryMove(double.Parse(arr[2])))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
            }
        }
    }
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption, double traveledDistance = 0)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = traveledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TraveledDistance { get; set; }

        public bool TryMove(double kmSum)
        {
            if ((kmSum * FuelConsumption) <= FuelAmount)
            {
                FuelAmount -= kmSum * FuelConsumption;
                TraveledDistance += kmSum;
                return true;
            }
            return false;
        }
    }
}

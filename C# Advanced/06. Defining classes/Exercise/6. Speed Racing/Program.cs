using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmouont = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuelConsumption, fuelAmouont);
                if (!cars.Contains(car))
                {
                    cars.Add(car);
                }
            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "End")
                {
                    break;
                }
                cars.First(x => x.Model == commands[1]).CanMove(double.Parse(commands[2]));
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}

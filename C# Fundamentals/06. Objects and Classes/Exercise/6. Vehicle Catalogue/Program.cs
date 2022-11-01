using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            while (true)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr[0] == "End")
                {
                    break;
                }

                switch (arr[0])
                {
                    case "truck":
                        vehicles.Add(new Vehicle(arr[0], arr[1], arr[2], int.Parse(arr[3])));
                        break;
                    case "car":
                        vehicles.Add(new Vehicle(arr[0], arr[1], arr[2], int.Parse(arr[3])));
                        break;
                }
            }


            while (true)
            {
                string model = Console.ReadLine();
                if (model == "Close the Catalogue")
                {
                    break;
                }
                Console.WriteLine(vehicles.Find(x => x.Model == model));
            }
            int sumCarHors = 0;
            int sumTruckHors = 0;
            foreach (var item in vehicles.Where(x => x.Model == "car"))
            {
                sumCarHors += item.HorsePower;
            }
            foreach (var item in vehicles.Where(x => x.Model == "truck"))
            {
                sumTruckHors += item.HorsePower;
            }
            Console.WriteLine($"Cars have average horsepower of: {vehicles.Where(x => x.Type == "car").Average(x => x.HorsePower):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {vehicles.Where(x => x.Type == "truck").Average(x => x.HorsePower):f2}.");

        }

        public class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsePower)
            {
                Type = type;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public override string ToString()
            {
                return $@"Type: {(this.Type == "car" ? "Car" : "Truck")}
Model: {Model}
Color: {Color}
Horsepower: {HorsePower}";
            }
        }
    }
}



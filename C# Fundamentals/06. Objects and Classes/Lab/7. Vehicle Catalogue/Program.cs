using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while (true)
            {
                string[] arr = Console.ReadLine().Split("/");
                if (arr[0] == "end")
                {
                    break;
                }

                if (arr[0] == "Car")
                {
                    Car car = new Car(arr[1], arr[2], int.Parse(arr[3]));
                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck(arr[1], arr[2], double.Parse(arr[3]));
                    trucks.Add(truck);
                }
            }
            catalog.Trucks = trucks;
            catalog.Cars = cars;

            if (catalog.Cars.Any())
            {

                Console.WriteLine("Cars:");
                foreach (var item in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Any())
            {

                Console.WriteLine("Trucks:");
                foreach (var item in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }



        }
    }
    public class Truck
    {
        public Truck(string brand, string model, double weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    public class Car
    {
        public Car(string brand, string model, double horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }
    public class Catalog
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }

}

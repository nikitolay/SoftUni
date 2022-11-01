using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

                string[] arr = Console.ReadLine().Split(' ');
                Engine engine = new Engine(int.Parse(arr[1]), int.Parse(arr[2]));
                Cargo cargo = new Cargo(int.Parse(arr[3]), arr[4]);
                Car car = new Car(arr[0], engine, cargo);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var item in cars.Where(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000))
                {
                    Console.WriteLine(item.Model);
                }
            }
            else
            {
                foreach (var item in cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
    public class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }

}

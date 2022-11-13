using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int speed = int.Parse(carInfo[1]);
                int power = int.Parse(carInfo[2]);
                Engine engine = new Engine(speed, power);
                int weight = int.Parse(carInfo[3]);
                string type = carInfo[4];
                Cargo cargo = new Cargo(weight, type);
                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(carInfo[5]),int.Parse(carInfo[6])) ,
                    new Tire(double.Parse(carInfo[7]),int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]),int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]),int.Parse(carInfo[12])),
                };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Console.WriteLine(string.Join("\n", cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1))));
            }
            else if (command == "flammable")
            {
                Console.WriteLine(string.Join("\n", cars.Where(x => x.Cargo.Type == "flammable" &&x.Engine.Power>250)));

            }
        }
    }
}

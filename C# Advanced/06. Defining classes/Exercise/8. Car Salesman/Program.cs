using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Car_Salesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //unfull exercise
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                int power = int.Parse(input[1]);
                Engine engine = new Engine(model, power);

                if (input.Length == 3 && (char.IsDigit(input[2][0])))
                {
                    int displacement = int.Parse(input[2]);
                    engine = new Engine(model, power, displacement);

                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);

                    string efficiency = input[3];
                    engine = new Engine(model, power, displacement, efficiency);

                }
                engines.Add(engine);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] info = Console.ReadLine().Split();
                string model = info[0];
                Engine engine = engines.First(x => x.Model == info[1]);
                Car car = new Car(model, engine);
                if (info.Length == 3 && (char.IsDigit(info[2][0]) || char.IsDigit(info[2][1])))
                {
                    int weight = int.Parse(info[2]);
                    car = new Car(model, engine, weight);

                }
                else if (info.Length == 4)
                {
                    int weight = int.Parse(info[2]);
                    string color = info[3];
                    car = new Car(model, engine, weight, color);
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

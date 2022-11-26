using System;

namespace T01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = Console.ReadLine().Split();
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Drive":
                        double distance = double.Parse(input[2]);
                        if (input[1] == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        break;
                    case "Refuel":
                        double litters = double.Parse(input[2]);

                        if (input[1] == "Car")
                        {
                            car.ReFuel(litters);
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.ReFuel(litters);
                        }
                        break;
                }
            }
            Console.WriteLine("Car: "+car.FuelQuantity.ToString("f2"));
            Console.WriteLine("Truck: "+truck.FuelQuantity.ToString("f2"));

        }
    }
}

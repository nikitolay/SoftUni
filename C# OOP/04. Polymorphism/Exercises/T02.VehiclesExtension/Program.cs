using System;

namespace T02.Vehicles_Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
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
                        else if (input[1] == "Bus")
                        {
                            bus.Drive(distance);
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
                        else if (input[1] == "Bus")
                        {
                            bus.ReFuel(litters);
                        }
                        break;
                    case "DriveEmpty":
                        double dist = double.Parse(input[2]);
                        bus.DriveEmpty(dist);

                        break;
                }
            }
            Console.WriteLine("Car: " + car.FuelQuantity.ToString("f2"));
            Console.WriteLine("Truck: " + truck.FuelQuantity.ToString("f2"));
            Console.WriteLine("Bus: " + bus.FuelQuantity.ToString("f2"));
        }
    }
}

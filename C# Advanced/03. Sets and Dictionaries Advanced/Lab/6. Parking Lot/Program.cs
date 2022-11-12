using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");
                if (input[0] == "END")
                {
                    break;
                }
                string direction=input[0]; 
                string carNumber=input[1];
                if (direction=="IN")
                {

                cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
            }
            if (cars.Any())
            {
                Console.WriteLine(string.Join("\n",cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

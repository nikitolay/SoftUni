using System;

namespace _1._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double result = n/1000.00000000;
            Console.WriteLine($"{result:f2}");
        }
    }
}

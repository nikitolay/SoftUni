using System;

namespace _3._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = Math.Abs(double.Parse(Console.ReadLine()));
            double m = Math.Abs(double.Parse(Console.ReadLine()));
            double difference = Math.Abs(n * 0.000001);
            if (Math.Abs(n - m) < difference)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}

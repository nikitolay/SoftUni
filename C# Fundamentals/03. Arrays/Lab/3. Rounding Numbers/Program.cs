using System;
using System.Linq;

namespace _3._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            foreach (double d in arr)
            {
                Console.WriteLine($"{d} => {Math.Round(d, MidpointRounding.AwayFromZero)}");
            }
        }     
    }
}

using System;

namespace _2._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            double gbp = 1.31;
            Console.WriteLine($"{n*gbp:F3}");
        }
    }
}

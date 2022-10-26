using System;

namespace _4._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
            int y = n * 100;
            int d = (int)(y * 365.2422);
            int h = d * 24;
            int m = h * 60;
            Console.WriteLine($"{n} centuries = {y} years = {d} days = {h} hours = {m} minutes");
        }
    }
}

using System;

namespace _3._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses=(int)(Math.Ceiling((decimal)n/ (decimal)capacity));
            Console.WriteLine(courses);

        }
    }
}

using System;

namespace _1._Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            CheckNumber(n);
        }
        public static void CheckNumber(int n)
        {
            if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }
            else if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");

            }
            else
            {
                Console.WriteLine($"The number {n} is zero.");
            }
        }
    }
}

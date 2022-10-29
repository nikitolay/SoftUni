using System;

namespace _8._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int first = Factorial(one);
            int second = Factorial(two);
            Console.WriteLine((first / second).ToString("F2"));
        }

        private static int Factorial(int one)
        {
            if (one == 1)
            {
                return 1;
            }
            return one * Factorial(one - 1);
        }
    }
}

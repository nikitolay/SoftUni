using System;

namespace _8._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            long result = MathPower(number, power);
            Console.WriteLine(result);
        }

        private static long MathPower(int number, int power)
        {
            long result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}

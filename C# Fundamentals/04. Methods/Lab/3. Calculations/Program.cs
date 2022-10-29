using System;

namespace _3._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Add(one, two);
                    break;
                case "multiply":
                    Multiply(one, two);
                    break;
                case "subtract":
                    Subtract(one, two);
                    break;
                case "divide":
                    Divide(one, two);
                    break;
                default:
                    break;
            }
        }

        private static void Divide(int one, int two)
        {
            Console.WriteLine(one / two);
        }

        private static void Subtract(int one, int two)
        {
            Console.WriteLine(one - two);
        }

        private static void Multiply(int one, int two)
        {
            Console.WriteLine(one * two);
        }

        private static void Add(int one, int two)
        {
            Console.WriteLine(one + two);
        }
    }
}

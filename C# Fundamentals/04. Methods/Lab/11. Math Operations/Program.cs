using System;

namespace _11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine(MathOperation(first, second, operation));
        }

        private static int MathOperation(int first, int second, string operation)
        {
            if (operation == "/")
            {
                return first / second;
            }
            else if (operation == "*")
            {
                return first * second;

            }
            else if (operation == "+")
            {
                return first + second;

            }
            else
            {
                return first - second;

            }
        }
    }
}

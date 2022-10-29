using System;

namespace _2._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            CheckGrades(n);
        }
        public static void CheckGrades(double n)
        {
            if (n >= 2 && n <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (n >= 3 && n <= 3.49)
            {
                Console.WriteLine("Poor");

            }
            else if (n >= 3.50 && n <= 4.49)
            {
                Console.WriteLine("Good");

            }
            else if (n >= 4.50 && n <= 5.49)
            {
                Console.WriteLine("Very good");

            }
            else if (n >= 5.50 && n <= 6)
            {
                Console.WriteLine("Excellent");

            }
        }
    }
}

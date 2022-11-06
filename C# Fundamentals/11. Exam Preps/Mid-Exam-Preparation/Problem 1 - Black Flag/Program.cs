using System;

namespace Problem_1___Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double result = 0;
            for (int i = 1; i <= days; i++)
            {
                result += dailyPlunder;
                if (i % 3 == 0)
                {
                    result += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    result -= result * 0.30;
                }

            }
            if (result >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {result:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(result / expectedPlunder) * 100:f2}% of the plunder.");
            }
        }
    }
}

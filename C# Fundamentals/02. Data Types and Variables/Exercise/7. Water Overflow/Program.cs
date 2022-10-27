using System;

namespace _7._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_CAPACITY = 255;
            int n = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                int m = int.Parse(Console.ReadLine());
                if (result + m > MAX_CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                result += m;
            }

            Console.WriteLine(result);




        }
    }
}

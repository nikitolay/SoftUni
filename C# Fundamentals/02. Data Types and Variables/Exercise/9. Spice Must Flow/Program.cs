using System;

namespace _9._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 0;
            int days = 0;
            while (true)
            {
                int temp = n;



                result += temp - 26;
                days++;

                n -= 10;

                if (n < 100)
                {
                    break;
                }

            }
            result -= 26;
            Console.WriteLine(days);
            Console.WriteLine(result);
        }
    }
}

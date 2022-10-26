using System;

namespace _5._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int index = i;
                if (i >= 10)
                {
                    int currN = i;
                    int sec = i % 10;
                    currN /= 10;
                    index=currN+ sec;
                    }
                if (index % 5 == 0 || index % 7 == 0 || index % 11 == 0)
                {

                    Console.WriteLine($"{i} -> True");
                }
                else
                {

                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}

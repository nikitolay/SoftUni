using System;
using System.Linq;

namespace _2._From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
                long sum = 0;

                if (input[0] > input[1])
                {
                    while (input[0] > 0)
                    {
                        sum += input[0] % 10;
                        input[0] /= 10;
                    }
                }
                else
                {
                    while (input[1] > 0)
                    {
                        sum += input[1] % 10;
                        input[1] /= 10;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}

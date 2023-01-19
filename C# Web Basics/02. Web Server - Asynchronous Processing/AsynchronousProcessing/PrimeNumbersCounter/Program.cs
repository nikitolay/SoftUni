using System.Diagnostics;

namespace PrimeNumbersCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long n = 10000000000;
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
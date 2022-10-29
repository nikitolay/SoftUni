using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = GetEvensSum(n);
            int oddSum = GetOddsSum(n);
            Console.WriteLine(evenSum * oddSum);
        }

        private static int GetOddsSum(int n)
        {

            int result = 0;
            for (int i = 0; i <= n + i - 1; i++)
            {
                if ((n % 10) % 2 != 0)
                {
                    result += n % 10;
                }
                n /= 10;
            }
            return result;
        }

        private static int GetEvensSum(int n)
        {
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                if ((n % 10) % 2 == 0)
                {
                    result += n % 10;
                }
                n /= 10;
            }
            return result;
        }
    }
}

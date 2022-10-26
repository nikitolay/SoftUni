using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int all = 0;
            int currentIndex = 0;
            bool isSpecial = false;
            for (int i = 1; i <= n; i++)
            {
                currentIndex = i;
                while (i > 0)
                {
                    all += i % 10;
                    i = i / 10;
                }
                isSpecial = (all == 5) || (all == 7) || (all == 11);
                Console.WriteLine("{0} -> {1}", currentIndex, isSpecial);
                all = 0;
                i = currentIndex;
            }

        }
    }
}

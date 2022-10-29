using System;

namespace _1._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSmallest(one, two, three));
        }

        private static int GetSmallest(int one, int two, int three)
        {
            int min = 0;
            if (one < two)
            {
                min = one;
            }
            else
            {
                min = two;
            }

            if (three < min)
            {
                min = three;
            }
            return min;
        }
    }
}

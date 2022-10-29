using System;

namespace _5._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());

            int countOfMinnus = 0;
            countOfMinnus += one < 0 ? 1 : 0;
            countOfMinnus += two < 0 ? 1 : 0;
            countOfMinnus += three < 0 ? 1 : 0;
            if (countOfMinnus % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else if (countOfMinnus % 2 != 0)
            {
                Console.WriteLine("negative");

            }
            else
            {
                Console.WriteLine("zero");
            }


        }
    }
}

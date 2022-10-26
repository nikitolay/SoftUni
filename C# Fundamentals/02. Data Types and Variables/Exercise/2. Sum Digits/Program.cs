using System;

namespace _2._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string na = Console.ReadLine();
            int n=int.Parse(na);
            int result = 0;
            for (int i = 0; i < na.Length; i++)
            {
                result += n%10;
                n /= 10;
            }
            Console.WriteLine(result);
        }
    }
}

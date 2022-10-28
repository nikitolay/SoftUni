using System;

namespace _3._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(FibRecursive(n));
        }
        static long FibRecursive(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }
    }
}

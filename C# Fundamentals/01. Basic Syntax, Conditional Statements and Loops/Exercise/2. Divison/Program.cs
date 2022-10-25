using System;

namespace _2._Divison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case int p when p%10==0:
                    Console.WriteLine("The number is divisible by 10");
                    break;
                case int p when p%7==0:
                    Console.WriteLine("The number is divisible by 7");
                    break;
                case int p when p%6==0:
                    Console.WriteLine(("The number is divisible by 6"));
                    break;
                case int p when p%3==0:
                    Console.WriteLine("The number is divisible by 3");
                    break;
                case int p when p%2==0:
                    Console.WriteLine("The number is divisible by 2");
                    break;
                default:
                    Console.WriteLine("Not divisible");
                    break;
            }
        }
    }
}

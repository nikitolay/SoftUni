using System;
using System.Linq;

namespace _1._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());
            double[] arr=new double[3] { first , second , third };

            Console.WriteLine(String.Join('\n',arr.OrderByDescending(X=>X)));
        }
    }
}

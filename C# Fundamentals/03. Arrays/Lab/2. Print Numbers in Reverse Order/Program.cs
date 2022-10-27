using System;
using System.Linq;

namespace _2._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i]= int.Parse(Console.ReadLine());
            }
            Console.WriteLine(String.Join(" ",arr.Reverse()));
        }
    }
}

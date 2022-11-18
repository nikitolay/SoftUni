using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arr, 0));
        }
        static int Sum(int[] arr, int index)
        {
            if (arr.Length == index)
            {
                return 0;
            }
            return arr[index] + Sum(arr, index + 1);
        }
    }
}

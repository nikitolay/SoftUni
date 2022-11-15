using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> SmallestNumber = input => input.Min();
            Console.WriteLine(SmallestNumber(nums));
        }
    }
}

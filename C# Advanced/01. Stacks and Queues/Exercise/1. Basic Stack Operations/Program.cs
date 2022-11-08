using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nums[0];
            int s = nums[1];
            int x = nums[2];
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            Console.WriteLine(stack.Contains(x) ? "true" : stack.Count > 0 ? stack.Min().ToString() : "0");
        }
    }
}

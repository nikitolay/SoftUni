using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> q = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int n = nums[0];
            int s = nums[1];
            int x = nums[2];
            for (int i = 0; i < s; i++)
            {
                if (q.Count > 0)
                {
                    q.Dequeue();
                }
            }
            Console.WriteLine(q.Contains(x) ? "true" : q.Count > 0 ? q.Min().ToString() : "0");
        }
    }
}

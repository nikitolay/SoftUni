using System;
using System.Linq;

namespace _8._Custom_Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", nums.OrderBy(x => x % 2 != 0)));
        }
    }
}

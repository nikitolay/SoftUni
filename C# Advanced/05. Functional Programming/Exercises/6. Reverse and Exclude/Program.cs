using System;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", nums.Reverse().Where(x => x % n != 0)));
        }
    }
}

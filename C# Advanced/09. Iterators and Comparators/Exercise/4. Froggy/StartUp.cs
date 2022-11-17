using System;
using System.Linq;

namespace _4._Froggy
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(nums.ToList());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}

using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] finalArray = new int[n];
            int[] finalArrayTwo = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    finalArray[i] = array[0];
                    finalArrayTwo[i] = array[1];
                }
                else
                {
                    finalArray[i] = array[1];
                    finalArrayTwo[i] = array[0];
                }
            }
            Console.WriteLine(String.Join(" ", finalArray));
            Console.WriteLine(String.Join(" ", finalArrayTwo));
        }
    }
}

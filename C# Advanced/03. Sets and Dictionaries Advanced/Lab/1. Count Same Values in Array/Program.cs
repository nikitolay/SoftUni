using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersWithCount = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersWithCount.ContainsKey(numbers[i]))
                {
                    numbersWithCount[numbers[i]]++;
                }
                else
                {
                    numbersWithCount[numbers[i]] = 1;
                }
            }
            foreach (var item in numbersWithCount)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

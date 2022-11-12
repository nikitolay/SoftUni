using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 1);
                }
                else
                {
                    numbers[num]++;
                }
            }
            Console.WriteLine(numbers.FirstOrDefault(x => x.Value % 2 == 0).Key);
        }
    }
}

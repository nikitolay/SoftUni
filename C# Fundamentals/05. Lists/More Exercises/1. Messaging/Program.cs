using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            StringBuilder text = new StringBuilder(Console.ReadLine().ToString());
            string result = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                while (numbers[i] > 0)
                {
                    sum += numbers[i] % 10;
                    numbers[i] /= 10;
                }
                if (sum > text.Length)
                {
                    int index = sum - text.Length;
                    result += text[index];
                    text.Remove(index, 1);
                }
                else
                {
                    result += text[sum];
                    text.Remove(sum, 1);
                }

            }
            Console.WriteLine(result);
        }
    }
}

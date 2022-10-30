using System;
using System.Collections.Generic;

namespace _3._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input = new List<string>();
            List<string> output = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr.Length == 3)
                {
                    if (input.Contains(arr[0]))
                    {
                        Console.WriteLine($"{arr[0]} is already in the list!");
                        continue;
                    }
                    input.Add(arr[0]);
                }
                else
                {
                    if (!input.Contains(arr[0]))
                    {
                        Console.WriteLine($"{arr[0]} is not in the list!");
                        continue;
                    }
                    input.Remove(arr[0]);
                    output.Add(arr[0]);

                }
            }
            Console.WriteLine(String.Join("\n", input));
        }
    }
}

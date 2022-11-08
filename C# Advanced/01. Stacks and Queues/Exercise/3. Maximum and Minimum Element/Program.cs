using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "1")
                {
                    stack.Push(int.Parse(input[1]));
                }
                if (stack.Count > 0)
                {
                    if (input[0] == "2")
                    {

                        stack.Pop();

                    }
                    else if (input[0] == "3")
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (input[0] == "4")
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}

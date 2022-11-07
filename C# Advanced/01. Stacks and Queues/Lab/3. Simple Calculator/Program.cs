using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            while (stack.Count > 1)
            {
                double first = double.Parse(stack.Pop());
                string @operator = stack.Pop();
                double second = double.Parse(stack.Pop());
                if (@operator == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else
                {
                    stack.Push((first - second).ToString());

                }

            }
            Console.WriteLine(stack.Pop());
        }
    }
}

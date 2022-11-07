using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < array.Length; i++)
            {
                stack.Push(array[i]);
            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0].ToLower() == "end")
                {
                    break;
                }
                switch (commands[0].ToLower())
                {
                    case "add":
                        stack.Push(int.Parse(commands[1]));
                        stack.Push(int.Parse(commands[2]));
                        break;
                    case "remove":
                        if (stack.Count > int.Parse(commands[1]))
                        {
                            for (int i = 0; i < int.Parse(commands[1]); i++)
                            {

                                stack.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i].ToString());
            }
            Console.WriteLine(string.Join("", stack));
        }
    }
}

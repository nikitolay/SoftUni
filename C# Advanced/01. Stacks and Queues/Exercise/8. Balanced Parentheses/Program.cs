using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (!stack.Any())
                    {
                        isValid = false;
                        break;
                    }
                    bool isValidFirst = input[i] == '}' && stack.Pop() == '{';
                    bool isValidSecon = input[i] == ')' && stack.Pop() == '(';
                    bool isValidThird = input[i] == ']' && stack.Pop() == '[';
                    if (!(isValidFirst || isValidSecon || isValidThird))
                    {
                        isValid = false;
                        break;
                    }

                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}


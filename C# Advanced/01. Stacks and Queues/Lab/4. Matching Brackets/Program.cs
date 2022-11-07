using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            List<string> substrings = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (text[i] == ')')
                {
                    int firstIndex = indexes.Pop();
                    int secondIndex = i;
                    string substring = text.Substring(firstIndex, secondIndex - firstIndex + 1);
                    substrings.Add(substring);
                }
            }
            foreach (var item in substrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}

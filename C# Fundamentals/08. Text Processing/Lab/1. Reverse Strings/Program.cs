using System;
using System.Linq;

namespace _1._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "end")
                {
                    break;
                }
                string reverseWord = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reverseWord += word[i];
                }
                Console.WriteLine($"{word} = {reverseWord}");
            }
        }
    }
}

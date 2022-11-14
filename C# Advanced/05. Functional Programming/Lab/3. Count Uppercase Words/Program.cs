using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Func<string, bool> IsUpperCase = input => char.IsUpper(input[0]);
            Console.WriteLine(string.Join("\n", words.Where(IsUpperCase)));
        }
    }
}

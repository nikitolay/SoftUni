using System;
using System.Text;

namespace _7._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = RepeatString(word, n);
            Console.WriteLine(result);
        }

        private static string RepeatString(string word, int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(word);
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Text;

namespace _3._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            Console.WriteLine(CharactersInRange(a, b));
        }

        private static string CharactersInRange(char a, char b)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (a.CompareTo(b) > 0)
            {
                char temp = a;
                a = b;
                b = temp;
            }
            for (int i = a + 1; i < b; i++)
            {
                stringBuilder.Append((char)i + " ");
            }
            return stringBuilder.ToString();
        }
    }
}

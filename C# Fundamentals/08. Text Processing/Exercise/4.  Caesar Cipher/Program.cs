using System;

namespace _4.__Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                int newChar = text[i] + 3;
                result += (char)newChar;
            }
            Console.WriteLine(result);
        }
    }
}

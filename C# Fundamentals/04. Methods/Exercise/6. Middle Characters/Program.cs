using System;

namespace _6._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintMiddleCharacters(word);
        }

        private static void PrintMiddleCharacters(string word)
        {
            string result = string.Empty;
            int middle = word.Length / 2;
            if (middle % 2 == 0)
            {
                result += word[middle - 1];
                result += word[middle];
            }
            else
            {
                result += word[middle];
            }

            Console.WriteLine(result);
        }
    }
}

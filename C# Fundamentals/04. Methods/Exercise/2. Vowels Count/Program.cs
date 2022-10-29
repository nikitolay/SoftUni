using System;

namespace _2._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(VowelsCount(word));
        }

        private static int VowelsCount(string word)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int currentLetter = word[i];
                if (currentLetter == 97 || currentLetter == 101 || currentLetter == 105 || currentLetter == 111 || currentLetter == 117
                           || currentLetter == 65 || currentLetter == 69 || currentLetter == 73 || currentLetter == 79 || currentLetter == 85)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

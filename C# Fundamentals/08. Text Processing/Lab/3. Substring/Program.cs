using System;
using System.Text;

namespace _3._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string word = Console.ReadLine();
            int index = word.IndexOf(wordToRemove);

            while (index != -1)
            {
                word = word.Remove(index, wordToRemove.Length);
                index = word.IndexOf(wordToRemove);
            }

            Console.WriteLine(word);
        }
    }
}

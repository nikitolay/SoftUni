﻿using System;
using System.Text;

namespace _5._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder allCharacters = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits.Append(text[i]);
                }
                else if (char.IsLetter(text[i]))
                {
                    letters.Append(text[i]);
                }
                else
                {
                    allCharacters.Append(text[i]);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(allCharacters);
        }
    }
}

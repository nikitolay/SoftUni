using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.__Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] alphaLower = "*abcdefghijklmnopqrstuvwxyz".ToCharArray();//first char is '*' because we counting from 1
            char[] alphaUpper = "*ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<string> list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            double finalSum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string strings = list[i];
                char firstLetter = strings[0];

                double number = int.Parse(strings.Substring(1, strings.Length - 1 - 1));

                if (char.IsUpper(firstLetter))
                {
                    number /= Array.IndexOf(alphaUpper, firstLetter);
                }
                else
                {
                    number *= Array.IndexOf(alphaLower, firstLetter);
                }

                char lastLetters = strings[strings.Length - 1];
                if (char.IsUpper(lastLetters))
                {
                    number -= Array.IndexOf(alphaUpper, lastLetters);
                }
                else
                {
                    number += Array.IndexOf(alphaLower, lastLetters);

                }
                finalSum += number;

            }
            Console.WriteLine($"{finalSum:f2}");

        }
    }
}

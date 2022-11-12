using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").Split();

            string[] lines = File.ReadAllLines("text.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string pattern = @$"\b{word}";

                wordsCount.Add(word, 0);

                for (int i = 0; i < lines.Length; i++)
                {
                    foreach (Match m in Regex.Matches(lines[i].ToLower(), pattern))
                    {
                        wordsCount[word]++;
                    }
                }
            }
            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("output.txt", $"{item.Key} - {item.Value}{Environment.NewLine}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (!symbols.ContainsKey(text[i]))
                {
                    symbols.Add(text[i], 1);
                }
                else
                {
                    symbols[text[i]]++;
                }
            }
            foreach (var item in symbols.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}

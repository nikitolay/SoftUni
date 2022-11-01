using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (dic.ContainsKey(word))
                {
                    dic[word].Add(synonym);
                }
                else
                {
                    dic.Add(word, new List<string>() { synonym });
                }
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> banList = Console.ReadLine().Split(", ").ToList();
            string text = Console.ReadLine();

            for (int i = 0; i < banList.Count; i++)
            {
                if (text.Contains(banList[i]))
                {
                    text = text.Replace(banList[i], new String('*', banList[i].Length));
                }
            }
            Console.WriteLine(text);
        }
    }
}

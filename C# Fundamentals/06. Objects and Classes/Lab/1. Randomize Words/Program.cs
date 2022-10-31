using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            Random random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = random.Next(0, list.Count - 1);
                Console.WriteLine(list[randomIndex]); ;
                list.RemoveAt(randomIndex);
                i--;
            }
        }
    }
}

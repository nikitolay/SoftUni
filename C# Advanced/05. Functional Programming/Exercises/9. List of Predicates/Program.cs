using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            bool isDevide = false;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j] == 0)
                    {
                        isDevide = true;

                    }
                    else
                    {
                        isDevide = false;
                        break;
                    }
                }
                if (isDevide)
                {
                    list.Add(i);
                    isDevide = false;
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace _5._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}

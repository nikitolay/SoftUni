﻿using System;
using System.Linq;

namespace _4._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            Console.WriteLine(string.Join(" ", arr.Reverse()));
        }
    }
}

﻿using System;

namespace _4._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                char b = char.Parse(Console.ReadLine());
                sum += b;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

﻿using System;

namespace _2._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int value = 1;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    if (k == 0 || i == 0)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = value * (i - k + 1) / k;

                    }
                    Console.Write(value + " ");
                }
                Console.WriteLine();

            }
        }
    }
}

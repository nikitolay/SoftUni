﻿using System;

namespace _2._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string result="";

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    result += input[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}

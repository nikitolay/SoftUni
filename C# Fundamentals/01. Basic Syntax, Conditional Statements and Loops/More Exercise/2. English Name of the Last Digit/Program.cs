using System;
using System.Collections.Generic;

namespace _2._English_Name_of_the_Last_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(EnglishNameOfTheLastDigit(n));
        }
        public static string EnglishNameOfTheLastDigit(int n)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>() 
            {

                { 1,"one"},
                { 2,"two"},
                { 3,"three"},
                { 4,"four"},
                { 5,"five"},
                { 6,"six"},
                { 7,"seven"},
                { 8,"eight"},
                { 9,"nine"},
                { 0,"zero"},

            };
            int newN = n % 10;
            
                return dic[newN];
           


        }
    }
}

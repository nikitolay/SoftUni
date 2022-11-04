using System;

namespace _2.__Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ');
            Console.WriteLine(Sum(strings[0], strings[1]));
        }
        static int Sum(string a, string b)
        {
            int sum = 0;
            int min = Math.Min(a.Length, b.Length);
            string maxLengthWord = a.Length > b.Length ? a : b;
            int index = 0;
            for (int i = 0; i < min; i++)
            {
                sum += a[i] * b[i];
                index++;
            }
            for (int i = index; i < maxLengthWord.Length; i++)
            {
                sum += maxLengthWord[i];
            }
            return sum;
        }
    }
}

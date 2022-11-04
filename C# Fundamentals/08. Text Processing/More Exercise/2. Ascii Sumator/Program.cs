using System;

namespace _2._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());

            char end = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] >= start && text[j] < end)
                {
                    sum += text[j];
                }
            }

            Console.WriteLine(sum);
        }
    }
}

using System;

namespace _6._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int brackets = 0;
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                if (text == "(" || text == ")")
                {
                    brackets++;
                }

            }
            if (brackets%2==0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

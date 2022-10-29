using System;
using System.Linq;

namespace _9._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            while (n != "END")
            {
                string reversed = string.Empty;

                for (int i = n.Length - 1; i >= 0; i--)
                {
                    reversed += n[i];

                }
                if (n == reversed)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
                n = Console.ReadLine();
            }
        }
    }
}

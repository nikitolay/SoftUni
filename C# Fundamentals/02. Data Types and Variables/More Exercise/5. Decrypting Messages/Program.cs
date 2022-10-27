using System;

namespace _5._Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            char a;
            for (int i = 0; i < n; i++)
            {
                a = char.Parse(Console.ReadLine());

                if (Char.IsUpper(a))
                {
                    result += char.ToUpper((char)(a + key));

                }
                else
                {

                    result += (char)(a + key);
                }
            }
            Console.WriteLine(result);
        }
    }
}

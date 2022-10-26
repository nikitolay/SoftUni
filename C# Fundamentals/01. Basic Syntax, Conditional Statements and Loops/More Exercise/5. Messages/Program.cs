using System;
using System.Text;

namespace _5._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int letters = int.Parse(Console.ReadLine());
            string word = String.Empty;

            for (int i = 1; i <= letters; i++)
            {
                string currentNum = Console.ReadLine();
                if (currentNum == "0")
                {
                    word += " ";
                    continue;
                }
                int length = currentNum.Length;
                int firstDigit = int.Parse(currentNum[0].ToString());
                if (firstDigit > 7)
                    word += (char)(97 + (firstDigit - 2) * 3 + length);
                else
                    word += (char)(97 + (firstDigit - 2) * 3 + length - 1);
            }
            Console.WriteLine(word);





        }
    }
}

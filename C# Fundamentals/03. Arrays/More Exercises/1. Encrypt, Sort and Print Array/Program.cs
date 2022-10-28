using System;
using System.Xml.Linq;

namespace _1._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int sumOfVowels = 0;
                double sumOfConsonant = 0;
                string word = Console.ReadLine();

                for (int j = 0; j < word.Length; j++)
                {
                    int currentLetter = word[j];
                    if (currentLetter == 97 || currentLetter == 101 || currentLetter == 105 || currentLetter == 111 || currentLetter == 117
                       || currentLetter == 65 || currentLetter == 69 || currentLetter == 73 || currentLetter == 79 || currentLetter == 85)
                    {
                        sumOfVowels += currentLetter * word.Length;
                    }
                    else
                    {
                        sumOfConsonant += currentLetter / word.Length;
                    }
                }
                sum = sumOfVowels + (int)sumOfConsonant;
                arr[i] = sum;

            }
            Array.Sort(arr);
            Console.WriteLine(String.Join("\n", arr));
        }
    }
}

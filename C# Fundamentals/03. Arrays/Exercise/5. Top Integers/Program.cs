using System;
using System.Linq;

namespace _5._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrTwo = new int[arr.Length];
            bool isGreater = true;
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                isGreater = true;
                for (int j = 1 + i; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isGreater = false;
                        break;
                    }

                }
                if (!isGreater)
                {
                    continue;
                }
                else
                {

                    arrTwo[index++] = arr[i];
                }
            }

            Console.WriteLine(String.Join(" ", arrTwo.Take(index)));
        }
    }
}

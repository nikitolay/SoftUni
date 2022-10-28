using System;
using System.Linq;

namespace _2._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();
            string[] arr3 = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr[i] == arr2[j])
                    {
                        arr3[j] = arr2[j];
                    }
                }
            }
            for (int j = 0; j < arr3.Length - 1; j++)
            {
                if (arr3[j] == null)
                {
                    string[] temp = new string[arr3.Length - 1];
                    for (int i = 0; i < arr3.Length - 1; i++)
                    {
                        arr3[j] = arr3[j + 1];
                    }

                }
            }
            Console.WriteLine(string.Join(" ", arr3.Distinct()));

        }
    }
}

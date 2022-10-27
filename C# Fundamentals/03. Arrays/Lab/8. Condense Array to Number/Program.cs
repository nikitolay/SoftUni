using System;
using System.Linq;

namespace _8._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] newarr = new int[arr.Length - 1];


            int length = newarr.Length;
            while (length > 0)
            {
                for (int i = 0; i < length; i++)
                {

                    newarr[i] = arr[i] + arr[i + 1];
                }
                arr = newarr;

                length--;
            }
            Console.WriteLine(arr[0]);

        }
    }
}

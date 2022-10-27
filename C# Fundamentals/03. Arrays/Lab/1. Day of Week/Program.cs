using System;

namespace _1._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] 
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };
            int n=int.Parse(Console.ReadLine());
            if (n>=1&&n<=7)
            {

            Console.WriteLine(arr[n-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}

using System;

namespace _5._Month_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mounts = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            int n = int.Parse(Console.ReadLine());
            if (n>12||n<1)
            {
               Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(mounts[n-1]);
            }
        }
    }
}

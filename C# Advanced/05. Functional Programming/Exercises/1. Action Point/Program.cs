using System;

namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> Print = input => Console.WriteLine(string.Join("\n", input));
            Print(names);
        }
    }
}

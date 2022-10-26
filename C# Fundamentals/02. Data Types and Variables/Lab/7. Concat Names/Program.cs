using System;

namespace _7._Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameF=Console.ReadLine();
            string nameL=Console.ReadLine();
            string delimiter = Console.ReadLine();
            Console.WriteLine(nameF+delimiter+nameL);
        }
    }
}

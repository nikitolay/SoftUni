using System;
using System.Linq;

namespace _4._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            string result=string.Empty;
           
            for (int i = name.Length - 1; i >= 0; i--)
            {
                result += name[i];
            }
            Console.WriteLine(result);
        }
    }
}

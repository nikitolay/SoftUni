using System;

namespace _1._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string element = Console.ReadLine();

            if (type == "int")
            {
                Console.WriteLine(int.Parse(element) * 2);
            }
            else if (type == "real")
            {
                Console.WriteLine((int.Parse(element) * 1.5).ToString("F2"));

            }
            else
            {
                Console.WriteLine($"${element}$");
            }
        }
    }
}

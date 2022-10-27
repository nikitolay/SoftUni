using System;

namespace _1._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                var n = int.TryParse(command, out int result);
                var m = double.TryParse(command, out double resultt);
                var p = char.TryParse(command, out char resulttt);
                var v = bool.TryParse(command, out bool resultttt);
                if (n)
                {
                    Console.WriteLine($"{command} is integer type");
                }

                else if (m)
                {
                    Console.WriteLine($"{command} is floating point type");
                }

                else if (p)
                {
                    Console.WriteLine($"{command} is character type");
                }

                else if (v)
                {
                    Console.WriteLine($"{command} is boolean type");

                }
                else
                {

                    Console.WriteLine($"{command} is string type");
                }

                command = Console.ReadLine();
            }
        }

    }
}

using System;

namespace _9._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string n = Console.ReadLine();
            string m = Console.ReadLine();
            switch (type)
            {
                case "int":
                    Console.WriteLine(GetMaxInt(int.Parse(n), int.Parse(m)));
                    break;
                case "char":
                    Console.WriteLine(GetMaxChar(char.Parse(n), char.Parse(m)));
                    break;
                case "string":
                    Console.WriteLine(GetMaxString(n, m));
                    break;
            }
        }

        private static string GetMaxString(string a, string b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static char GetMaxChar(char a, char b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static int GetMaxInt(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}

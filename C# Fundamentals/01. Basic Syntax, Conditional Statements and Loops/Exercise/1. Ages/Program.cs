using System;

namespace _1._Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case int p when p>=0&&p<=2:
                    Console.WriteLine("baby");
                    break;
                    case int p when p>=3&&p<=13:
                    Console.WriteLine("child");
                    break;
                case int p when p>=14&&p<=19:
                    Console.WriteLine("teenager");
                    break;
                case int p when p>=20&&p<=65:
                    Console.WriteLine("adult");
                    break;
                default:
                    Console.WriteLine("elder");
                    break;
            }
        }
    }
}

using System;

namespace _6._Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());
            char[] arr =new char[3] {three,two,one};
            Console.WriteLine(string.Join(" ",arr));


        }
    }
}

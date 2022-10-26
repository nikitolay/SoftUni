using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           // Console.Write("Length: ");
            double dul = double.Parse(Console.ReadLine());
            //Console.Write("Width: ");
            double sh = double.Parse(Console.ReadLine());
          //  Console.Write("Heigth: ");
            double v = double.Parse(Console.ReadLine());
            v= (dul * sh * v) / 3;
            Console.Write($"Length: Width: Height: Pyramid Volume: {v:f2}");

        }
    }
}

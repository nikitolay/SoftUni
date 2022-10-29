using System;

namespace _6._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width=int.Parse(Console.ReadLine());
            int height=int.Parse(Console.ReadLine());
            int area = GetRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static int GetRectangleArea(int width, int height)
        {
           return (width * height);
        }
    }
}

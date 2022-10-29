using System;

namespace _2._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            CenterPoint(x1, y1, x2, y2);
        }

        private static void CenterPoint(int x1, int y1, int x2, int y2)
        {
            int first = CalculateDistance(x1, y1);
            int second = CalculateDistance(x2, y2);
            if (first > second)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else if (first <= second)
            {
                Console.WriteLine($"({x1}, {y1})");

            }
        }
        private static int CalculateDistance(int first, int second)
        {
            return Math.Max(Math.Abs(first), Math.Abs(second));
        }
    }
}

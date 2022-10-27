using System;

namespace _10._Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int target = 0;
            int temp = n;
            while (true)
            {

                int targetPoket = temp - m;
                target++;

                if (targetPoket == n * 0.5)
                {
                    targetPoket = targetPoket / y;
                    Console.WriteLine(targetPoket);
                    Console.WriteLine(target);
                    break;
                }
                if (targetPoket < m)
                {
                    Console.WriteLine(targetPoket);
                    Console.WriteLine(target);
                    break;
                }
                temp -= m;
            }



        }
    }
}

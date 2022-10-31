using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            double totalTimeLeft = 0;
            double totalTimeRight = 0;
            int middle = (int)(list.Count / 2);

            for (int i = 0; i < middle; i++)
            {
                if (list[i] == 0)
                {
                    totalTimeLeft *= .8;
                }
                else
                {
                    totalTimeLeft += list[i];
                }
            }
            for (int j = middle + 1; j < list.Count; j++)
            {
                if (list[j] == 0)
                {
                    totalTimeRight *= .8;
                }
                else
                {
                    totalTimeRight += list[j];
                }
            }
            if (totalTimeLeft > totalTimeRight)
            {

                Console.WriteLine($"The winner is right with total time: {totalTimeRight}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {totalTimeLeft}");

            }
        }
    }
}

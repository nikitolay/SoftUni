using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cupsCapacity = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottle = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wasteWater = 0;
            while (cupsCapacity.Any() && bottle.Any())
            {
                int currentBottle = bottle.Pop();
                if (currentBottle >= cupsCapacity.First())
                {
                    wasteWater += currentBottle - cupsCapacity.First();
                    cupsCapacity[0] -= currentBottle;
                }
                else
                {
                    while (cupsCapacity[0] > 0 && bottle.Any())
                    {
                        currentBottle += bottle.Pop();
                        if (currentBottle >= cupsCapacity.First())
                        {
                            wasteWater += currentBottle - cupsCapacity.First();
                            cupsCapacity[0] -= currentBottle;
                        }
                    }
                }
                if (cupsCapacity[0] <= 0)
                {
                    cupsCapacity.RemoveAt(0);
                }
            }

            if (bottle.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottle)}");
            }
            else if (cupsCapacity.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasteWater}");
        }

    }
}

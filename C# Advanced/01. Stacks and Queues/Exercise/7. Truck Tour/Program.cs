using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumpData = new Queue<string>();
            int tank = 0;
            for (int i = 0; i < n; i++)
            {
                pumpData.Enqueue(Console.ReadLine());
            }
            bool isSuccessfull = true;
            for (int i = 0; i < n; i++)
            {
                isSuccessfull = true;
                int currentPetrolAmount = 0;
                for (int j = 0; j < n; j++)
                {
                    int[] input = pumpData.Dequeue().Split().Select(int.Parse).ToArray();
                    pumpData.Enqueue(string.Join(" ", input));
                    currentPetrolAmount += input[0];
                    currentPetrolAmount -= input[1];
                    if (currentPetrolAmount < 0)
                    {
                        isSuccessfull = false;
                    }
                }
                if (isSuccessfull)
                {
                    Console.WriteLine(i);
                    break;
                }
                string tempData = pumpData.Dequeue();
                pumpData.Enqueue(tempData);
            }
        }
    }
}

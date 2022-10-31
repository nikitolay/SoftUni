using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumList = new List<int>(drumSet);
            string command = Console.ReadLine();
            while (command != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;


                    if (drumSet[i] <= 0)
                    {
                        int price = drumList[i] * 3;
                        if (savings < price)
                        {
                            int removedDrum = drumSet.First(x => x <= 0);
                            drumSet.Remove(removedDrum);
                            drumList.RemoveAt(i);
                            i--;
                        }
                        else
                        {

                            savings -= price;
                            drumSet[i] = drumList[i];
                        }
                    }
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}

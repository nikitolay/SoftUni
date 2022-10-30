using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Add":
                        list.Add(int.Parse(command[1]));
                        break;
                    default:
                        int passengers = int.Parse(command[0]);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] + passengers <= maxCapacity)
                            {
                                list[i] += passengers;
                                break;
                            }
                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}

using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            while (true)
            {

                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (map.ContainsKey(resource))
                {
                    map[resource] += quantity;
                }
                else
                {

                    map.Add(resource, quantity);
                }
            }
            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                List<string> list = Console.ReadLine().Split().ToList();
                string command = list[0];
                string username = list[1];
                switch (command)
                {
                    case "register":
                        string licensePlateNumber = list[2];
                        if (parking.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                            continue;
                        }

                        parking[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        break;
                    case "unregister":
                        if (parking.ContainsKey(username))
                        {
                            parking.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                }
            }
            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}

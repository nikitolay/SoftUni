using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace Problem_2._Mu_Online
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double health = 100;
            double bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            int countOfRoom = 0;
            bool isDied = false;
            for (int i = 0; i < rooms.Count; i++)
            {

                string[] room = rooms[i].Split();
                string command = room[0];
                double number = double.Parse(room[1]);
                switch (command)
                {
                    case "potion":
                        if (number + health <= 100)
                        {
                            health += number;
                            Console.WriteLine($"You healed for {number} hp.");
                        }
                        else
                        {
                            double oldHealth = health;
                            health = 100;
                            Console.WriteLine($"You healed for {health - oldHealth} hp.");
                        }
                        Console.WriteLine($"Current health: {health} hp.");
                        countOfRoom++;

                        break;
                    case "chest":
                        bitcoins += number;
                        countOfRoom++;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        countOfRoom++;
                        health -= number;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            isDied = true;
                        }
                        break;
                }
                if (isDied)
                {
                    break;
                }
            }
            if (countOfRoom == rooms.Count())
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}

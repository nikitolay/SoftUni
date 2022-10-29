using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            bool isModified = false;
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Contains":
                        if (list.Contains(int.Parse(command[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(String.Join(" ", list.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(String.Join(" ", list.Where(x => x % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(list.Sum());
                        break;
                    case "Filter":
                        int number = int.Parse(command[2]);
                        if (command[1] == "<")
                        {
                            Console.WriteLine(String.Join(" ", list.Where(x => x < number)));
                        }
                        else if (command[1] == "<=")
                        {
                            Console.WriteLine(String.Join(" ", list.Where(x => x <= number)));

                        }
                        else if (command[1] == ">")
                        {
                            Console.WriteLine(String.Join(" ", list.Where(x => x > number)));

                        }
                        else if (command[1] == ">=")
                        {
                            Console.WriteLine(String.Join(" ", list.Where(x => x >= number)));

                        }
                        break;
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {

                switch (command[0])
                {
                    case "Delete":
                        list.RemoveAll(x => x == int.Parse(command[1]));
                        break;
                    case "Insert":
                        list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}

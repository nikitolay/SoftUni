using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    internal class Program
    {
        static bool IsOutside(int n, List<int> list)
        {
            return n < 0 || n >= list.Count;
        }
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Add":
                        list.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        if (IsOutside(int.Parse(command[2]), list))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {

                            list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        }
                        break;
                    case "Remove":
                        if (IsOutside(int.Parse(command[1]), list))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(int.Parse(command[1]));

                        }
                        break;
                    case "Shift":

                        if (command[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int first = list[0];
                                list.RemoveAt(0);
                                list.Add(first);
                            }

                        }
                        else
                        {

                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int end = list[list.Count - 1];
                                list.RemoveAt(list.Count - 1);
                                list.Insert(0, end);
                            }
                        }

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

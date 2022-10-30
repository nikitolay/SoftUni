using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "3:1")
                {
                    break;
                }
                switch (commands[0])
                {
                    case "merge":
                        string newString = "";
                        int count = 0;
                        int startIndex = int.Parse(commands[1]);
                        if (startIndex > list.Count)
                        {
                            startIndex = 0;
                        }
                        int endIndex = int.Parse(commands[2]);
                        if (endIndex > list.Count)
                        {
                            endIndex = list.Count;
                            count++;
                        }
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            newString += list[i];
                            list.RemoveAt(i);
                            i--;
                            if (count == endIndex - startIndex)
                            {
                                list.Insert(startIndex, newString);
                                break;
                            }
                            count++;
                        }
                        break;
                    case "divide":
                        int index = int.Parse(commands[1]);
                        if (index == list.Count)
                        {
                            index = 0;
                        }
                        int partitions = int.Parse(commands[2]);
                        string newStrings = "";
                        int lengthString = list[index].Length / partitions;
                        for (int i = 0; i <= partitions + lengthString + 1; i += lengthString)
                        {
                            newStrings += list[index].Substring(i, lengthString) + " ";

                        }
                        list.RemoveAt(index);
                        list.Insert(index, newStrings);
                        break;
                }

            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace _10.__SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            string[] command = Console.ReadLine().Split(":");
            while (command[0] != "course start")
            {
                string lessonTitle = command[1];
                switch (command[0])
                {
                    case "Add":
                        if (!list.Contains(lessonTitle))
                        {

                            list.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!list.Contains(command[1]))
                        {

                            int index = int.Parse(command[2]);
                            list.Insert(index, lessonTitle);
                        }


                        break;
                    case "Remove":
                        if (list.Contains(command[1]))
                        {
                            list.Remove(command[1]);
                        }
                        break;
                    case "Swap":
                        string firstTitle = command[1];
                        string secondTitle = command[2];
                        if (list.Contains(firstTitle) && list.Contains(secondTitle))
                        {

                            int firstIndex = list.IndexOf(firstTitle);
                            int secondIndex = list.IndexOf(secondTitle);
                            list[firstIndex] = secondTitle;
                            list[secondIndex] = firstTitle;
                            if (list.Contains($"{firstTitle}-Exercise"))
                            {
                                int indexOfExercise = list.IndexOf($"{firstTitle}-Exercise");
                                list.Insert(secondIndex + 1, list[indexOfExercise]);
                                list.RemoveAt(indexOfExercise + 1);
                            }
                            if (list.Contains($"{secondTitle}-Exercise"))
                            {
                                int indexOfExercise = list.IndexOf($"{secondTitle}-Exercise");
                                list.Insert(firstIndex + 1, list[indexOfExercise]);
                                list.RemoveAt(indexOfExercise + 1);
                            }
                        }
                        else if (list.Contains($"{firstTitle}-Exercise") && list.Contains($"{secondTitle}-Exercise"))
                        {
                            int firstIndex = list.IndexOf(firstTitle);
                            int secondIndex = list.IndexOf(secondTitle);
                            list[firstIndex] = secondTitle;
                            list[secondIndex] = firstTitle;
                        }
                        break;
                    case "Exercise":
                        if (list.Contains(lessonTitle))
                        {
                            int indexOfTitle = list.IndexOf(lessonTitle);
                            list[indexOfTitle] = $"{lessonTitle}-Exercise";
                        }
                        else
                        {
                            list.Add(lessonTitle);
                            list.Add($"{lessonTitle}-Exercise");
                        }
                        break;
                }
                command = Console.ReadLine().Split(":");
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }
    }
}


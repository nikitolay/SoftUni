using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Mixed_Up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finalList = new List<int>();

            for (int i = 0; i < listOne.Count; i++)
            {
                for (int j = listTwo.Count - 1 - i; j >= 0; j--)
                {
                    finalList.Add(listOne[i]);
                    finalList.Add(listTwo[j]);
                    listOne.RemoveAt(i);
                    listTwo.RemoveAt(j);
                    if (!listOne.Any())
                    {
                        break;
                    }

                }

            }
            int start = 0;
            int end = 0;
            if (listOne.Any())
            {
                start = Math.Min(listOne[0], listOne[1]);
                end = Math.Max(listOne[0], listOne[1]);
                finalList.Remove(start);
                finalList.Remove(end);
                Console.WriteLine(String.Join(" ", finalList.Where(x => x >= start && x <= end).OrderBy(x => x)));
            }
            else
            {
                start = Math.Min(listTwo[0], listTwo[1]);
                end = Math.Max(listTwo[0], listTwo[1]);
                finalList.Remove(start);
                finalList.Remove(end);
                Console.WriteLine(String.Join(" ", finalList.Where(x => x >= start && x <= end).OrderBy(x => x)));
            }
        }
    }
}

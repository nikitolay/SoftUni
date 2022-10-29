using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            int smallestList = list.Count < listTwo.Count ? list.Count : listTwo.Count < list.Count ? listTwo.Count : list.Count;
            int largestList = list.Count > listTwo.Count ? 0 : listTwo.Count > list.Count ? 1 : -1;
            List<int> newList = new List<int>();
            int index = 0;
            for (int i = 0; i < smallestList; i++)
            {
                newList.Add(list[i]);
                newList.Add(listTwo[i]);
                index++;
            }
            if (largestList == 0)
            {

                newList.AddRange(list.Skip(index));
            }
            else if (largestList == 1)
            {
                newList.AddRange(listTwo.Skip(index));

            }
            Console.WriteLine(String.Join(" ", newList));
        }
    }
}

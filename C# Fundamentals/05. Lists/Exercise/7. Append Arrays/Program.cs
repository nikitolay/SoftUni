using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> list1 = new List<int>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                int[] stringlist = list.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < stringlist.Length; j++)
                {
                    list1.Add(stringlist[j]);

                }
                list.Remove(list.Last());
                i = -1;
            }

            Console.WriteLine(String.Join(" ", list1));
        }
    }
}

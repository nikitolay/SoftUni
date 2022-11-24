using System;
using System.Collections.Generic;

namespace _8._Collection_Hierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> first = new List<int>();
            List<int> second = new List<int>();
            List<int> third = new List<int>();
            List<string> fourth = new List<string>();
            List<string> fifth = new List<string>();

            string[] elements = Console.ReadLine().Split();
            for (int i = 0; i < elements.Length; i++)
            {
                first.Add(addCollection.Add(elements[i]));
                second.Add(addRemoveCollection.Add(elements[i]));
                third.Add(myList.Add(elements[i]));
            }
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                fourth.Add(addRemoveCollection.Remove());
                fifth.Add(myList.Remove());
            }
            Console.WriteLine(string.Join(" ",first));
            Console.WriteLine(string.Join(" ",second));
            Console.WriteLine(string.Join(" ",third));
            Console.WriteLine(string.Join(" ",fourth));
            Console.WriteLine(string.Join(" ",fifth));
        }
    }
}

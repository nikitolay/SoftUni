using System;
using System.Collections.Generic;

namespace _6._Equality_Logic
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> list = new SortedSet<Person>();
            HashSet<Person> set = new HashSet<Person>(new PersonEqualityComparer());
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                list.Add(person);
                set.Add(person);
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(set.Count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Comparing_Objects
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                Person person = new Person(name, age, town);
                persons.Add(person);

            }
            int n = int.Parse(Console.ReadLine());
            Person person1 = persons[n - 1];
            int equalToHim = 0;
            int notEqualToHim = 0;

            foreach (var item in persons)
            {
                if (item.CompareTo(person1) == 0)
                {
                    equalToHim++;
                }
                else if (item.CompareTo(person1) != 0)
                {
                    notEqualToHim++;
                }
            }
            if (equalToHim <=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalToHim} {notEqualToHim} {persons.Count()}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                Person person = new Person(arr[0], int.Parse(arr[1]));
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember());
        }
    }
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
    public class Family
    {
        public Family()
        {
            Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void AddMember(Person person)
        {
            Persons.Add(person);
        }
        public Person GetOldestMember()
        {
            return Persons.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }

}

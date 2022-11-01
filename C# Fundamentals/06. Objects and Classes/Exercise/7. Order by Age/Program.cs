using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string[] arr = Console.ReadLine().Split();
                if (arr[0] == "End")
                {
                    break;
                }
                string name = arr[0];
                string id = arr[1];
                int age = int.Parse(arr[2]);
                if (persons.Any(x => x.Id == id))
                {
                    Person person = persons.FirstOrDefault(x => x.Id == id);
                    person.Age = age;
                    person.Name = name;
                }
                else
                {
                    Person person = new Person(name, id, age);
                    persons.Add(person);
                }
            }
            foreach (var item in persons.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }

}

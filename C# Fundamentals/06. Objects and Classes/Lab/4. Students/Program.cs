using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                string[] arr = Console.ReadLine().Split().ToArray();
                if (arr[0] == "end")
                {
                    break;
                }
                Student student = new Student(arr[0], arr[1], int.Parse(arr[2]), arr[3]);
                students.Add(student);

            }
            string city = Console.ReadLine();
            foreach (var student in students.Where(x => x.Town == city))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
        public class Student
        {
            public Student(string firstName, string lastName, int age, string town)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Town = town;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Town { get; set; }
        }

    }
}

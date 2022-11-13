using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person(string name, int age)
            : this()
        {
            Name = name;
            Age = age;
        }
        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age)
            : this()
        {
            Age = age;
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}

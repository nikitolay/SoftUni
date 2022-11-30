using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        [MyRequired]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [MyRange(12, 90)]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }


    }
}

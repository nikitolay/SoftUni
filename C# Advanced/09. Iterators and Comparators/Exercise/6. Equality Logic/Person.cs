using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _6._Equality_Logic
{
    internal class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int names = Name.CompareTo(other.Name);
            return names == 0 ? Age.CompareTo(other.Age) : names;
        }
    }
}

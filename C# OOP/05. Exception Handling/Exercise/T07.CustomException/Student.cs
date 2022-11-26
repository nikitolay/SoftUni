using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T07.CustomException
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {

                if (value.Any(x => char.IsDigit(x) || char.IsSymbol(x)))
                {
                    throw new InvalidPersonNameException("The first name cannot be null or empty.");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Any(x => char.IsDigit(x) || char.IsSymbol(x)))
                {
                    throw new InvalidPersonNameException("The last name cannot be null or empty.");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in the range [0 .. 120].");
                }
                age = value;
            }
        }

    }
}

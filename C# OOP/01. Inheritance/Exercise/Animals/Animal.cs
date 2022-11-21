using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private Gender gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        private int age;

        public int Age
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        private string name;

        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");

                }
                name = value;
            }
        }


        private string Gender
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || !Enum.TryParse(value, out Gender genderr))
                {
                    throw new ArgumentException("Invalid input!");

                }
                this.gender = genderr;
            }
        }


        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{name} {age} {gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().Trim();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Birthday_Celebrations
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }
        public string BirthDate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}

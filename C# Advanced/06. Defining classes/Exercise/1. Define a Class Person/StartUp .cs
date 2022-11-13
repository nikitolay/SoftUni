using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", 20);
            Person personTwo = new Person();
            personTwo.Name = "George";
            personTwo.Age = 18;
            Person personThird = new Person("Jose", 43);

        }
    }
}

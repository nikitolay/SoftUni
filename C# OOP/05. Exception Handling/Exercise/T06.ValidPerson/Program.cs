using System;

namespace T06.ValidPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Person", "Johnson", 24);

            }
            catch (ArgumentException e)
            {

                Console.WriteLine($"Exception thrown: {e.Message}");
            }

            try
            {
                Person personWithoutFirstName = new Person(string.Empty, "Peterson", 24);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");

            }

            try
            {

                Person personWithoutLastName = new Person("Jordon", string.Empty, 24);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");

            }

            try
            {
                Person personWithNegativeAge = new Person("Peter", "Miller", -1);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");

            }

            try
            {

                Person personWithTooBigAge = new Person("Peter", "Miller", 122);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");

            }


        }
    }
}

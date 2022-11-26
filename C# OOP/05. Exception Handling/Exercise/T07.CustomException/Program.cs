using System;

namespace T07.CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student person = new Student("P3t3r", "Johnson", 24);

            }
            catch (InvalidPersonNameException e)
            {

                Console.WriteLine($"Exception thrown: {e.Message}");
            }


        }
    }
}

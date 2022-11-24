using System;

namespace _9._Explicit_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                Citizen citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

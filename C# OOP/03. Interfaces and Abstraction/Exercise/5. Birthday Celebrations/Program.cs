using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Birthday_Celebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Robot> robots = new List<Robot>();
            List<Citizen> citizens = new List<Citizen>();
            List<Pet> pets = new List<Pet>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End")
                {
                    break;
                }
                if (input[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    citizens.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    pets.Add(pet);
                }
                else if (input[0] == "Robot")
                {
                    Robot robot = new Robot(input[0], input[1]);
                    robots.Add(robot);
                }
            }
            string fakeIdEnd = Console.ReadLine();
            foreach (var cit in citizens.Where(x => x.BirthDate.EndsWith(fakeIdEnd)))
            {
                Console.WriteLine(cit.BirthDate);
            }
            foreach (var pet in pets.Where(x => x.BirthDate.EndsWith(fakeIdEnd)))
            {
                Console.WriteLine(pet.BirthDate);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {

                string[] animal = Console.ReadLine().Split();
                string name = animal[0];
                int age = int.Parse(animal[1]);
                string gender = animal[2];
                try
                {
                    switch (input)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }


            foreach (var animal in animals)
            {
               // Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
               // animal.ProduceSound();
            }
        }
    }
}

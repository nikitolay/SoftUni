using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string[] animalInfo = Console.ReadLine().Split();
            while (animalInfo[0] != "End")
            {


                try
                {
                    Animal animal = CreateAnimal(animalInfo);
                    animals.Add(animal);
                    Console.WriteLine(animal.AskForFood());

                    string[] foods = Console.ReadLine().Split();
                    string foodName = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Food food = CreateFood(foodName, quantity);
                    animal.Eat(food);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



                animalInfo = Console.ReadLine().Split();
            }
            foreach (var a in animals)
            {
                Console.WriteLine(a);
            }
        }

        private static Food CreateFood(string foodName, int quantity)
        {
            Food food = null;
            switch (foodName)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }
            return food;
        }

        private static Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal = null;
            switch (animalInfo[0])
            {
                case "Cat":
                    animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3], animalInfo[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3], animalInfo[4]);

                    break;
                case "Owl":
                    animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), 0, double.Parse(animalInfo[3]));
                    break;
                case "Hen":
                    animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), 0, double.Parse(animalInfo[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3]);
                    break;
                case "Dog":
                    animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3]);
                    break;
                default:
                    break;
            }
            return animal;
        }
    }
}

using System;
using System.Collections.Generic;

namespace _4._Pizza_Calories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaInfo[1], dough);
                string[] toppingInfo = Console.ReadLine().Split();
                while (toppingInfo[0] != "END")
                {
                    string name = toppingInfo[1];
                    double weight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(name, weight);
                    pizza.Add(topping);
                    toppingInfo = Console.ReadLine().Split();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

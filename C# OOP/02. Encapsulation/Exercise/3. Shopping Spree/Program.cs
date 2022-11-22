using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            try
            {


                string[] peopleInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleInput.Length / 2 + 1; i++)
                {
                    Person person = new Person(peopleInput[i], decimal.Parse(peopleInput[i + 1]));
                    i++;
                    persons.Add(person);
                }
                List<string> productsInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<Product> products = new List<Product>();

                for (int i = 0; i < productsInput.Count / 2 + 1; i++)
                {
                    Product product = new Product(productsInput[i], decimal.Parse(productsInput[i + 1]));
                    i++;
                    products.Add(product);
                }
                string[] command = Console.ReadLine().Split();
                while (command[0] != "END")
                {
                    Person person = persons.FirstOrDefault(x => x.Name == command[0]);
                    Product product = products.FirstOrDefault(x => x.Name == command[1]);
                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product}");
                    }
                    else
                    {
                        person.Money -= product.Cost;
                        person.Bag.Add(product);
                        Console.WriteLine($"{person.Name} bought {product}");
                    }
                    command = Console.ReadLine().Split();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (var person1 in persons)
            {
                string productsBag = person1.Bag.Count > 0 ? string.Join(", ", person1.Bag) : "Nothing bought";
                Console.WriteLine($"{person1.Name} - {productsBag}");
            }

        }
    }
}

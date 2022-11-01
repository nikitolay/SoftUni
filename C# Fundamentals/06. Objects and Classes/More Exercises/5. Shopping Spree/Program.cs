using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products1 = new List<Product>();
            List<string> people = Console.ReadLine().Split(new[] { '=', ';' }).ToList();
            for (int i = 0; i < people.Count; i++)
            {
                Person person = new Person(people[0], decimal.Parse(people[1]));
                people.RemoveAt(0);
                people.RemoveAt(0);
                persons.Add(person);
            }

            List<string> products = Console.ReadLine().Split(new[] { '=', ';' }).ToList();
            for (int i = 0; i < products.Count; i++)
            {
                Product person = new Product(products[0], decimal.Parse(products[1]));
                products.RemoveAt(0);
                products.RemoveAt(0);
                products1.Add(person);
            }

            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                if (input[0] == "END")
                {
                    break;
                }
                Person person = persons.Find(x => x.Name.Equals(input[0]));
                Product product = products1.Find(x => x.Name.Equals(input[1]));
                if (person.Money < product.Price)
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");

                }
                else
                {
                    person.Money -= product.Price;
                    person.Products.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }
            string nothinBought = "Nothing bought";
            foreach (var item in persons)
            {

                Console.WriteLine($"{item.Name} - {(item.Products.Any() ? string.Join(", ", item.Products) : nothinBought)}");
            }
        }
    }
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
    public class Person
    {
        public Person()
        {
            Products = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace _1._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> phrases = new List<string>()
            {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
            List<string> events = new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int phrase = rand.Next(phrases.Count - 1);
                int @event = rand.Next(events.Count - 1);
                int author = rand.Next(authors.Count - 1);
                int city = rand.Next(cities.Count - 1);

                Console.WriteLine($"{phrases[phrase]} {events[@event]} {authors[author]} – {cities[city]}");
            }
        }
    }
}

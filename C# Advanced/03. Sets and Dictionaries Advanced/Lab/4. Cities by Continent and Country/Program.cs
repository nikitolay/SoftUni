using System;
using System.Collections.Generic;

namespace _4._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string country = data[1];
                string city = data[2];
                if (!continentCountryCities.ContainsKey(continent))
                {
                    continentCountryCities.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentCountryCities[continent].ContainsKey(country))
                {
                    continentCountryCities[continent].Add(country, new List<string>());
                }
                continentCountryCities[continent][country].Add(city);

            }
            foreach (var item in continentCountryCities)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var element in item.Value)
                {
                    Console.WriteLine($"  {element.Key} -> {string.Join(", ", element.Value)}");
                }
            }
        }
    }
}

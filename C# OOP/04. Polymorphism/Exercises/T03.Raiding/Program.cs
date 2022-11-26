using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                HeroCreator creator = new HeroCreator();
                string name = Console.ReadLine();
                string hero = Console.ReadLine();
                try
                {
                    BaseHero hero1 = creator.CreateHero(hero, name);
                    heroes.Add(hero1);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int countOfHeroPowers = heroes.Sum(x => x.Power);
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }
            if (countOfHeroPowers >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> peoples = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            Predicate<string> predicat;
            while (command != "Party!")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = commands[0];
                string criteria = commands[1];
                string parameter = commands[2];
                predicat = GetPredicate(criteria, parameter);
                if (type == "Remove")
                {
                    peoples.RemoveAll(predicat);
                }
                else if (type == "Double")
                {
                    List<string> newPeople = peoples.FindAll(predicat);
                    foreach (var item in newPeople)
                    {
                        int indexOfPeople = peoples.IndexOf(item);
                        peoples.Insert(indexOfPeople + 1, item);
                    }
                }

                command = Console.ReadLine();
            }
            if (peoples.Any())
            {



                Console.WriteLine(String.Join(", ", peoples) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }



        }
        static Predicate<string> GetPredicate(string criteria, string parameter)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(parameter);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(parameter);

            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(parameter);

            }
            else
            {
                return null;
            }
        }

    }
}

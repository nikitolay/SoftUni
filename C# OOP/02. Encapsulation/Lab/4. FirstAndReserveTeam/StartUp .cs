﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {



            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                try
                {

                    var person = new Person(cmdArgs[0],
                        cmdArgs[1],
                        int.Parse(cmdArgs[2]),
                        decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            /*First team has 4 players.
Reserve team has 1 players.
*/
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }

    }
}

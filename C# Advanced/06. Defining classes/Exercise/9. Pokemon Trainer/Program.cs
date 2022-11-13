using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Trainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "Tournament")
                {
                    break;
                }
                string trainerName = commands[0];
                string pokemonName = commands[1];
                string pokemonElement = commands[2];
                int pokemonHealth = int.Parse(commands[3]);
                if (trainers.Any(x => x.Name == trainerName))
                {
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    trainers.First(x => x.Name == trainerName).Pokemons.Add(pokemon);
                }
                else
                {

                    Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    Trainer trainer = new Trainer(trainerName, new List<Pokemon>() { pokemon });
                    trainers.Add(trainer);
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (trainers.Any(x => x.Pokemons.Any(x => x.Element == command)))
                {
                    Trainer tr = trainers.First(x => x.Pokemons.Any(x => x.Element == command));
                    tr.Badges++;
                }
                else
                {
                    trainers.Where(x => x.Pokemons.Any(x => x.Element != command)).Select(x => x.Pokemons.Select(x => x.Health -= 10));


                }
                foreach (var item in trainers)
                {
                    if (item.Pokemons.Any(x => x.Health <= 0))
                    {
                        Trainer trainer = trainers.First(x => x.Pokemons.Any(x => x.Health <= 0));
                        Pokemon pokemon = trainer.Pokemons.First(x => x.Health <= 0);
                        trainer.Pokemons.Remove(pokemon);
                    }
                }
            }
            foreach (var item in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Pokemon_Trainer
{
    internal class Trainer
    {
        public Trainer(string name, List<Pokemon> pokemons, int badges=0)
        {
            Name = name;
            Badges = badges;
            Pokemons = pokemons;
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}

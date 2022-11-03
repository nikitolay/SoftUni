using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _4._Snowwhite
{
    public class Dwarf
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Physics { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dwarf>> alldwarfs = new Dictionary<string, List<Dwarf>>();
            List<Dwarf> result = new List<Dwarf>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Once upon a time")
                {
                    break;
                }

                string[] input = command.Split(" <:> ");
                string name = input[0];
                string colour = input[1];
                int physics = int.Parse(input[2]);

                if (!alldwarfs.ContainsKey(colour))
                {
                    alldwarfs[colour] = new List<Dwarf>();
                }
                if (!alldwarfs[colour].Any(x => x.Name == name))
                {
                    Dwarf dwarf = new Dwarf();
                    dwarf.Name = name;
                    dwarf.Physics = physics;
                    dwarf.Colour = colour;
                    alldwarfs[colour].Add(dwarf);
                    result.Add(dwarf);
                }
                else
                {
                    var tempDwarf = alldwarfs[colour].FirstOrDefault(x => x.Name == name);
                    tempDwarf.Physics = Math.Max(tempDwarf.Physics, physics);
                }
            }
            result = result.OrderByDescending(x => x.Physics).ThenByDescending(a => alldwarfs[a.Colour].Count).ToList();
            foreach (var dwarf in result)
            {

                Console.WriteLine($"({dwarf.Colour}) {dwarf.Name} <-> {dwarf.Physics}");

            }
        }
    }
}















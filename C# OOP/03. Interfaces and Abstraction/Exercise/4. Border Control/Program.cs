using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Border_Control
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Robot> robots = new List<Robot>();
            List<Citizen> citizens = new List<Citizen>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End")
                {
                    break;
                }
                if (input.Length == 2)
                {
                    Robot robot = new Robot(input[0], input[1]);
                    robots.Add(robot);
                }
                else if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    citizens.Add(citizen);
                }
            }
            string fakeIdEnd = Console.ReadLine();
            foreach (var cit in citizens.Where(x => x.Id.EndsWith(fakeIdEnd)))
            {
                Console.WriteLine(cit.Id);
            }
            foreach (var rob in robots.Where(x => x.Id.EndsWith(fakeIdEnd)))
            {
                Console.WriteLine(rob.Id);
            }
        }
    }
}

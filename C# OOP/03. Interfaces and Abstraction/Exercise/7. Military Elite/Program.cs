using _7._Military_Elite.Enumerations;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Military_Elite
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<ISoldier> soldiers = new HashSet<ISoldier>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Private")
                {
                    string id = input[1];
                    string firstName = input[2];
                    string secondName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    Private soldier = new Private(id, firstName, secondName, salary);
                    soldiers.Add(soldier);

                }
                else if (input[0] == "LieutenantGeneral")
                {
                    string id = input[1];
                    string firstName = input[2];
                    string secondName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    List<IPrivate> privates = new List<IPrivate>();
                    for (int i = 5; i < input.Length; i++)
                    {
                        IPrivate @private = (IPrivate)soldiers.First(x => x.Id == input[i]);
                        privates.Add(@private);
                    }
                    LieutenantGeneral soldier = new LieutenantGeneral(id, firstName, secondName, salary, privates);
                    soldiers.Add(soldier);
                }
                else if (input[0] == "Engineer")
                {
                    string id = input[1];
                    string firstName = input[2];
                    string secondName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    bool isValidCorps = Enum.TryParse(input[5], out Corps corps);
                    List<IRepair> repairs = new List<IRepair>();
                    if (isValidCorps)
                    {
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            repairs.Add(new Repair(input[i], int.Parse(input[i + 1])));
                        }
                        Engineer soldier = new Engineer(id, firstName, secondName, salary, corps, repairs);
                        soldiers.Add(soldier);
                    }
                }
                else if (input[0] == "Commando")
                {
                    string id = input[1];
                    string firstName = input[2];
                    string secondName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    bool isValidCorps = Enum.TryParse(input[5], out Corps corps);
                    List<IMissions> missions = new List<IMissions>();
                    if (isValidCorps)
                    {
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            bool isValidState = Enum.TryParse(input[i + 1], out State state);
                            if (isValidState)
                            {

                                missions.Add(new Mission(input[i], state));
                            }
                        }
                        Commando soldier = new Commando(id, firstName, secondName, salary, corps, missions);
                        soldiers.Add(soldier);
                    }
                }
                else if (input[0] == "Spy")
                {
                    string id = input[1];
                    string firstName = input[2];
                    string secondName = input[3];
                    int codeNumber = int.Parse(input[4]);
                    Spy soldier = new Spy(id, firstName, secondName, codeNumber);
                    soldiers.Add(soldier);
                }


            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

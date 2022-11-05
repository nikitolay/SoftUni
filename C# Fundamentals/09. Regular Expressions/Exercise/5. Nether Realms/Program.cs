using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.\,0-9 ]";
            string damagePattern = @"-?\d\.?\d*";
            string multiplyDividePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();
            for (int i = 0; i < demons.Length; i++)
            {
                string currDemon = demons[i];
                MatchCollection healthMatched = Regex.Matches(currDemon, healthPattern);
                long health = 0;
                foreach (Match match in healthMatched)
                {
                    char currChar = char.Parse(match.ToString());
                    health += currChar;
                }
                double damage = 0;
                MatchCollection damageMatched = Regex.Matches(currDemon, damagePattern);
                foreach (Match match in damageMatched)
                {
                    double currentDamage = double.Parse(match.ToString());
                    damage += currentDamage;
                }
                MatchCollection multyplyAnDividers = Regex.Matches(currDemon, multiplyDividePattern);
                foreach (Match multyplyAndDivider in multyplyAnDividers)
                {
                    char currentOperator = char.Parse(multyplyAndDivider.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{currDemon} - {health} health, {damage:f2} damage");


            }

        }
    }
}

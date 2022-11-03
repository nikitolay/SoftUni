using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPossitionSkill = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }
                if (input.Contains(" -> "))
                {
                    List<string> list = input.Split(" -> ").ToList();
                    string player = list[0];
                    string posstition = list[1];
                    int skill = int.Parse(list[2]);
                    if (playerPossitionSkill.ContainsKey(player))
                    {
                        if (playerPossitionSkill[player].ContainsKey(posstition))
                        {
                            if (playerPossitionSkill[player][posstition] < skill)
                            {

                                playerPossitionSkill[player][posstition] = skill;
                            }
                        }
                        else
                        {
                            playerPossitionSkill[player].Add(posstition, skill);
                        }
                    }
                    else
                    {
                        playerPossitionSkill.Add(player, new Dictionary<string, int>());
                        playerPossitionSkill[player].Add(posstition, skill);
                    }
                }
                else
                {
                    List<string> list = input.Split(" vs ").ToList();
                    string firstPlayer = list[0];
                    string secoondPlayer = list[1];
                    string playerToRemove = "";
                    if (playerPossitionSkill.ContainsKey(firstPlayer) && playerPossitionSkill.ContainsKey(secoondPlayer))
                    {
                        foreach (var item in playerPossitionSkill[firstPlayer])
                        {
                            foreach (var fi in playerPossitionSkill[secoondPlayer])
                            {
                                if (item.Key == fi.Key)
                                {
                                    if (item.Value > fi.Value)
                                    {
                                        playerToRemove = secoondPlayer;
                                    }
                                    else if (item.Value < fi.Value)
                                    {
                                        playerToRemove = firstPlayer;
                                    }
                                }
                            }
                        }
                        playerPossitionSkill.Remove(playerToRemove);

                    }
                }
            }
            foreach (var item in playerPossitionSkill.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
                foreach (var e in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {e.Key} <::> {e.Value}");
                }
            }
        }
    }
}

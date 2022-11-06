using System;
using System.Collections.Generic;
using System.Linq;

namespace _3___The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                List<string> list = Console.ReadLine().Split("|").ToList();
                string piece = list[0];
                string composer = list[1];
                string key = list[2];
                dic.Add(piece, new List<string>());
                dic[piece].Add(composer);
                dic[piece].Add(key);
            }
            while (true)
            {

                List<string> list = Console.ReadLine().Split("|").ToList();
                if (list[0] == "Stop")
                {
                    break;
                }
                string piece = list[1];
                switch (list[0])
                {
                    case "Add":
                        //piece = list[1];
                        string composer = list[2];
                        string key = list[3];
                        if (dic.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            dic.Add(piece, new List<string>());
                            dic[piece].Add(composer);
                            dic[piece].Add(key);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        //  piece = list[1];

                        if (dic.ContainsKey(piece))
                        {
                            dic.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = list[2];
                        if (dic.ContainsKey(piece))
                        {
                            dic[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> keys = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> gold = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }
                StringBuilder text = new StringBuilder(input);

                int indexOfKey = 0;
                string type = "";
                int countOfTypeSymbols = 0;// when they turn 2 we have taken the floor

                string coordinates = "";
                int countOfCoordinateSymbols = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] -= (char)keys[indexOfKey];
                    if (indexOfKey == keys.Count - 1)
                    {
                        indexOfKey = 0;
                    }
                    else
                    {
                        indexOfKey++;
                    }

                    if (text[i] == '&')
                    {
                        countOfTypeSymbols++;

                    }
                    if (countOfTypeSymbols > 0 && countOfTypeSymbols < 2 && text[i] != '&')
                    {
                        type += text[i];
                    }

                    if (text[i] == '<' || text[i] == '>')
                    {
                        countOfCoordinateSymbols++;
                    }
                    if (countOfCoordinateSymbols > 0 && countOfCoordinateSymbols < 2 && text[i] != '<' && text[i] != '>')
                    {
                        coordinates += text[i];
                    }
                }

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}

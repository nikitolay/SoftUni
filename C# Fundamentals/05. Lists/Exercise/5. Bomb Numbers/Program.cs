using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombWithPower = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bomb = bombWithPower[0];
            int power = bombWithPower[1];
            int countOfBomb = list.Count(x => x == bomb);
            for (int i = 0; i < countOfBomb; i++)
            {
                int index = list.IndexOf(bomb) - power;
                if (index < 0)
                {
                    index = 0;
                }
                int indexTwo = list.IndexOf(bomb) + power;
                if (indexTwo > list.Count)
                {
                    indexTwo = list.Count - 1;
                }
                for (int j = index; j <= indexTwo; j++)
                {
                    list.RemoveAt(index);

                }
                countOfBomb = list.Count(x => x == bomb);
                i = -1;
            }
            Console.WriteLine(String.Join(" ", list.Sum()));
        }
    }
}

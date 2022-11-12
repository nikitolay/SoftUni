using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            for (int i = 0; i < array[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }
            for (int i = 0; i < array[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (setOne.Contains(num))
                {

                    setTwo.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", setTwo));
        }
    }
}

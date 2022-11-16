using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                box.Add(data);
            }
            int[] comands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapAndPrint(comands[0], comands[1]);
            Console.WriteLine(box);
        }

    }
}

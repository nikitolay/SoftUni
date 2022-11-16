using System;
using System.Linq;

namespace _4._GenericSwapMethodIntegers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int data = int.Parse(Console.ReadLine());
                box.Add(data);
            }
            int[] comands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapAndPrint(comands[0], comands[1]);
            Console.WriteLine(box);
        }
    }
}

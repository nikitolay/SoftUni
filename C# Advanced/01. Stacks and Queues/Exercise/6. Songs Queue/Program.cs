using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", "));
            queue.Reverse();
            while (true)
            {
                string input = Console.ReadLine();
                if (queue.Count == 0)
                {
                    Console.WriteLine($"No more songs!");
                    break;
                }
                switch (input[0])
                {
                    case 'P':
                        queue.Dequeue();
                        break;
                    case 'A':
                        input = input.Remove(0, 4);
                        if (!queue.Contains(input))
                        {
                            queue.Enqueue(input);
                        }
                        else
                        {
                            Console.WriteLine($"{input} is already contained!");

                        }
                        break;
                    case 'S':
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

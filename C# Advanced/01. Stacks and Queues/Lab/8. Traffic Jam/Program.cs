using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int passed = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {

                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            passed++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

            }
            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}

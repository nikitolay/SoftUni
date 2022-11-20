using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int task = int.Parse(Console.ReadLine());
            while (true)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();
                if (currTask == task)
                {
                    break;
                }
                if (currThread >= currTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (currThread < currTask)
                {
                    threads.Dequeue();
                }

            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Peek()}");
            Console.WriteLine($"{string.Join(" ", threads)}");
        }
    }
}

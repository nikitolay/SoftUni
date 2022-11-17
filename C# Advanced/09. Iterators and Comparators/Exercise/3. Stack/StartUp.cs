using System;
using System.Linq;

namespace _3._Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(new[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "END")
                {
                    break;
                }
                if (commands[0] == "Push")
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        stack.Push(int.Parse(commands[i]));
                    }
                }
                else if (commands[0]=="Pop")
                {
                    stack.Pop();
                }
            }
            if (stack.Any())
            {

            Console.WriteLine(string.Join("\n",stack));
            Console.WriteLine(string.Join("\n", stack));
                
            }
        }
    }
}

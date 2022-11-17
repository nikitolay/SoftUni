using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._ListyIterator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split().Skip(1).ToArray();
            ListyIterator<string> listyIterator2 = new ListyIterator<string>(commands);
            while (true)
            {
                commands = Console.ReadLine().Split();
                if (commands[0] == "END")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Move":
                        Console.WriteLine(listyIterator2.Move());

                        break;
                    case "Print":

                        listyIterator2.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator2.HasNext());

                        break;
                    default:
                        break;
                }

            }
        }
    }
}

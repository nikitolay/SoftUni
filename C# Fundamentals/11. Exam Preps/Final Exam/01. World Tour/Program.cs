using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            while (true)
            {

                List<string> command = Console.ReadLine().Split(":").ToList();
                if (command[0] == "Travel")
                {
                    break;
                }
                switch (command[0])
                {
                    case "Add Stop":
                        int index = int.Parse(command[1]);
                        string text = command[2];
                        // initialString = initialString.Remove(index, text.Length );
                        if (index >= 0 && index < initialString.Length)
                        {

                            initialString = initialString.Insert(index, text);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        if (startIndex >= 0 && startIndex < initialString.Length && endIndex >= 0 && initialString.Length - endIndex < startIndex)
                        {

                            initialString = initialString.Remove(startIndex, endIndex - startIndex + 1);

                        }
                        break;
                    case "Switch":
                        string old = command[1];
                        string @new = command[2];
                        while (initialString.Contains(old))
                        {

                            initialString = initialString.Replace(old, @new);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(initialString);

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {initialString}");
        }
    }
}

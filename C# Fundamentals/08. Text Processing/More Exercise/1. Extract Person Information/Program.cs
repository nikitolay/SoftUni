using System;
using System.Collections.Generic;

namespace _1._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nameWithAge = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = "";
                string age = "";
                string text = Console.ReadLine();
                int startIndexOfName = text.IndexOf('@') + 1;//+1 to skip @ in begining
                int endIndexOfName = text.IndexOf('|');

                int startIndexOfAge = text.IndexOf('#') + 1;//+1 to skip # in begining
                int endIndexOfAge = text.IndexOf('*');

                for (int j = startIndexOfName; j < endIndexOfName; j++)
                {
                    name += text[j];
                }
                for (int k = startIndexOfAge; k < endIndexOfAge; k++)
                {
                    age += text[k];
                }
                nameWithAge.Add(name, int.Parse(age));
            }
            foreach (var person in nameWithAge)
            {
                Console.WriteLine($"{person.Key} is {person.Value} years old.");
            }
        }
    }
}

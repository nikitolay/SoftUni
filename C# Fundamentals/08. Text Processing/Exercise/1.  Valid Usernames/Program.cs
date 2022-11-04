using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.__Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            StringBuilder validNames = new StringBuilder();
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i].Length > 3 && names[i].Length < 16)
                {
                    bool isValid = true;
                    for (int j = 0; j < names[i].Length; j++)
                    {
                        if (!(char.IsLetterOrDigit(names[i][j]) || names[i][j].Equals('_') || names[i][j].Equals('-')))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validNames.AppendLine(names[i]);
                    }
                }
            }
            Console.WriteLine(validNames);
        }
    }
}

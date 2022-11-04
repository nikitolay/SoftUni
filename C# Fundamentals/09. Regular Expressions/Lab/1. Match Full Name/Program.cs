using System;
using System.Text.RegularExpressions;

namespace _1._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"\b[A-Z][a-z]+ [A-Z][a-z]+");

            foreach (Match item in matches)
            {
                Console.Write(item.Value + " ");
            }
        }
    }
}

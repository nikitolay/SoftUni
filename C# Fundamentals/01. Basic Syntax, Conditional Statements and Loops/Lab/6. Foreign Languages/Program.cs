using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Foreign_Languages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> keyValuePairs = new Dictionary<string, string>()
            {
                { "England" ,"English"},
                { "USA","English" },
               { "Spain" ,"Spanish"}    ,
               { "Argentina","Spanish"},
               { "Mexico" ,"Spanish"  }
            };
            string country=Console.ReadLine();
            
            if (keyValuePairs.ContainsKey(country))
            {
                Console.WriteLine(keyValuePairs.Where(x=>x.Key==country).First().Value);
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}

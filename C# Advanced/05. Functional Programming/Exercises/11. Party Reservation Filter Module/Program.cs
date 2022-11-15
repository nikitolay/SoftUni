using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> people = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();
            while (true)
            {
                string[] data = Console.ReadLine().Split(";");
                if (data[0] == "Print")
                {
                    break;
                }
                if (data[0] == "Add filter")
                {

                    filters.Add($"{data[1]};{data[2]}");

                }
                else if (data[0] == "Remove filter")
                {
                    filters.Remove($"{data[1]};{data[2]}");
                }
            }
            foreach (var item in filters)
            {
                string[] info = item.Split(";");
                if (info[0] == "Starts with")
                {
                    // List<string> newPersons = people.FindAll(x => x.StartsWith(info[1]));

                    people.RemoveAll(x => x.StartsWith(info[1]));
                }
                else if (info[0] == "Ends with")
                {
                    people.RemoveAll(x => x.EndsWith(info[1]));

                }
                else if (info[0] == "Length")
                {
                    people.RemoveAll(x => x.Length == int.Parse(info[1]));

                }
                else if (info[0] == "Contains")
                {
                    people.RemoveAll(x => x.Contains(info[1]));

                }
            }
            if (people.Any())
            {
                Console.WriteLine(string.Join(" ", people));
            }
      
        }
    }
}

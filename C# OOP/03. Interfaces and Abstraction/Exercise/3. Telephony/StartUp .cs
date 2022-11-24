using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split().ToList();
            List<string> websites = Console.ReadLine().Split().ToList();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                if (!phoneNumbers[i].Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (phoneNumbers[i].Length == 10)
                {
                    smartphone.PhoneNumber = phoneNumbers[i];
                    smartphone.Call();
                }
                else if (phoneNumbers[i].Length == 7)
                {
                    stationaryPhone.PhoneNumber = phoneNumbers[i];
                    stationaryPhone.Call();
                }
            }
            for (int i = 0; i < websites.Count; i++)
            {
                if (websites[i].Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                smartphone.Site = websites[i];
                smartphone.Browsing();
            }
        }
    }
}

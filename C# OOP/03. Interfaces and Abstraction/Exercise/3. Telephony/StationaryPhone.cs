using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Telephony
{
    public class StationaryPhone : ICallable
    {
        public string PhoneNumber { get; set; }
        public void Call()
        {
            Console.WriteLine($"Dialing... {PhoneNumber}");
        }
    }
}

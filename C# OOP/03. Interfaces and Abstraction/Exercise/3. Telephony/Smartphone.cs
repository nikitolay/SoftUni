using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Site { get; set; }
        public string PhoneNumber { get; set; }

        public void Browsing()
        {
            Console.WriteLine($"Browsing... {Site}");
        }

        public void Call()
        {
            Console.WriteLine($"Calling... {PhoneNumber}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace T02._Facade
{
    public class Car
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string NumberOfDors { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDors}, Manufactured in {City}, at address: {Address}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DEFAULT_PRICE = 3.50m;
        private const int DEFAULT_MILLILITERS = 50;

        public double CoffeeMilliliters { get; set; }
        public decimal CoffeePrice { get; set; }
        public double Caffeine { get; set; }
        public Coffee(string name)
            : base(name, DEFAULT_PRICE, DEFAULT_MILLILITERS)
        {
        }
    }
}

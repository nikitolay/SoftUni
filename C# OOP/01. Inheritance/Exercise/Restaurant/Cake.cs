using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DEFAULT_PRICE = 5;
        private const double DEFAULT_GRAMS = 250;
        private const double DEFAULT_CALORIES = 250;

        public Cake(string name) 
            : base(name, DEFAULT_PRICE, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Shopping_Spree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
           private set { name = value; }
        }

        public decimal Cost
        {
            get { return cost; }
           private set { cost = value; }
        }
        public override string ToString()
        {

            return $"{Name}";
        }
    }
}

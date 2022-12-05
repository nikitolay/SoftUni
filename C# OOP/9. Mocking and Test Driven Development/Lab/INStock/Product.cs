using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => this.label;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of product should not be null");
                }
                this.label = value;

            }
        }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("The price can not be zero");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price can not be negative number");
                }
                this.price = value;
            }

        }

        public int Quantity
        {

            get => this.quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The quantity can not be negative number");
                }
                this.quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            return label.CompareTo(other.Label);
        }
    }
}

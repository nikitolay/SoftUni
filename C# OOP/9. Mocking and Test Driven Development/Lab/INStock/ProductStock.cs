using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products = new List<IProduct>();

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get => products[index];
            set
            {
                if (index >= 0 && index < products.Count)
                {
                    products[index] = value;

                }

            }
        }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (!Contains(product))
            {
                products.Add(product);

            }
        }

        public bool Contains(IProduct product)
                => products.Any(x => x.Label == product.Label);

        public IProduct Find(int index)
        {
            if (index < 0 || index >= products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            IProduct product = products[index];
            return product;

        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            IEnumerable<IProduct> products = this.products.FindAll(x => x.Price == (decimal)price);
            return products;

        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            IEnumerable<IProduct> products = this.products.FindAll(x => x.Quantity == (decimal)quantity);
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return products;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            IEnumerable<IProduct> products = this.products.FindAll(x => x.Price >= (decimal)lo && x.Price <= (decimal)hi);
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            return products;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = products.FirstOrDefault(x => x.Label == label);
            if (product == null)
            {
                throw new ArgumentException();
            }
            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct product = products.OrderByDescending(x => x.Price).FirstOrDefault();
            return product;
        }


        public bool Remove(IProduct product)
        {
            if (Contains(product))
            {
                products.Remove(product);
                return true;
            }
            return false;
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

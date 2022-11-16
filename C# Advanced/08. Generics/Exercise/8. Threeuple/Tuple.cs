using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Threeuple
{
    public class Tuple<T, V,K>
    {
        public Tuple(T item1, V item2, K item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public T item1 { get; set; }
        public V item2 { get; set; }
        public K item3 { get; set; }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}

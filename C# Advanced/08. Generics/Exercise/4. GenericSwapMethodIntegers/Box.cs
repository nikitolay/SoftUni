using System;
using System.Collections.Generic;
using System.Text;

namespace _4._GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public List<T> Items { get; set; }
        public Box()
        {
            Items = new List<T>();
        }
        public void Add(T item)
        {
            Items.Add(item);
        }
        public void SwapAndPrint(int first, int second)
        {
            T firstItem = Items[first];
            T secondItem = Items[second];
            Items[second] = firstItem;
            Items[first] = secondItem;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{item.GetType()}: {item}");
            }
            return stringBuilder.ToString();
        }
    }
}

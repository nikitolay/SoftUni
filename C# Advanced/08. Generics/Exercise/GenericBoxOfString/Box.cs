using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        public T Item { get; set; }
        public Box(T item)
        {
            Item = item;
        }
        public override string ToString()
        {
            return $"{Item.GetType()}: {Item}";
        }
    }
}

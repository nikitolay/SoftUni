using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        Stack<T> items;
        public Box()
        {
            items = new Stack<T>();
        }
        public int Count => items.Count;
        public void Add(T item)
        {
            items.Push(item);
        }
        public T Remove()
        {
            if (Count >= 1)
            {
               return items.Pop();
            }
            return default;
        }
    }
}

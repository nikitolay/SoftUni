using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3._Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> items;
        private int last;

        public Stack()
        {
            items= new List<T>();
            last=-1;
        }
        public void Push(T element)
        {
            items.Add(element);
            last++;
        }
        public void Pop()
        {
            if (items.Count==0)
            {
                Console.WriteLine("No elements");
                return;
            }
            items.RemoveAt(last);
            last--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

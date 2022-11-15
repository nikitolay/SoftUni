using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Data_Structures
{
    internal class CustomStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] items;
        public CustomStack()
        {
            items = new T[INITIAL_CAPACITY];
            Count = 0;
        }
        public int Count { get; private set; }

        public void Push(T item)
        {
            if (items.Length == Count)
            {
                T[] temp = new T[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    temp[i] = items[i];
                }
                items = temp;
            }
            items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int lastIndex = Count - 1;
            T last = items[lastIndex];
            Count--;
            return last;
        }
        public T Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            return items[Count - 1];
        }
        public void ForEach(Action<Object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
    }
}

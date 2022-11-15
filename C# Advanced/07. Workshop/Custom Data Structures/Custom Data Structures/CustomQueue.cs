using System;
using System.Text;

namespace Custom_Data_Structures
{
    internal class CustomQueue<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private const int FIRST_ELEMENT_INDEX = 4;
        private T[] items;

        public CustomQueue()
        {
            items = new T[INITIAL_CAPACITY];
            Count = 0;
        }
        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (items.Length == Count)
            {
                IncreaseSize();
            }
            items[Count] = element;
            Count++;
        }
        public T Dequeue()
        {
            IsEmpty();
            Count--;
            return items[0];
        }

        public void SwitchElements()
        {
            items[0] = default;//first element
            for (int i = 1; i < items.Length; i++)
            {
                items[i - 1] = items[i];
            }
            items[items.Length] = default;
        }
        public void Clear()
        {
            IsEmpty();
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = default;
            }
        }
        public T Peek()
        {
            IsEmpty();
            return items[0];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < items.Length; i++)
            {
                action(items[i]);
            }
        }
        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            };
        }

        private void IncreaseSize()
        {
            T[] temp = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Custom_Data_Structures
{
    internal class CustomList<T>
    {
        private const int INITIAL_CAPACITY = 2;
        private T[] items;

        public CustomList()
        {
            items = new T[INITIAL_CAPACITY];
            Count = 0;
        }

        public int Count { get; private set; }

        public T this[int i]
        {
            get
            {
                if (i >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[i];
            }
            set
            {
                if (i >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[i] = value;
            }
        }

        public void Add(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }

        public T RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            T removed = items[index];
            items[index] = default(T);
            Shift(index);
            Count--;
            if (Count < items.Length / 4)
            {
                Shrink();
            }
            return removed;
        }

        public void Insert(int index, T item)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex > Count || secondIndex > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            T first = items[firstIndex];
            T second = items[secondIndex];
            items[firstIndex] = second;
            items[secondIndex] = first;
        }
        private void ShiftToRight(int index)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            for (int i = Count + 1; i < index; i--)//pravim edno mwsto swobodno
            {
                items[i] = items[i - 1];
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            T[] temp = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        private void Resize()
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

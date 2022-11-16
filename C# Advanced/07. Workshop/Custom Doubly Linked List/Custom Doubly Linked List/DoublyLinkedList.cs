using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Doubly_Linked_List
{
    internal class DoublyLinkedList<T>
    {
        private class Node<T>
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }
        }
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                head = new Node<T>(element);
                tail = new Node<T>(element);
            }
            else
            {
                var newHead = new Node<T>(element);
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = new Node<T>(element);
                tail = new Node<T>(element);
            }
            else
            {
                var newTail = new Node<T>(element);
                tail.Next = newTail;
                newTail.Previous = tail;
                tail = newTail;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;
            head = head.Next;
            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return firstElement;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = tail.Value;
            tail = tail.Previous;
            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            var currentNode = head;
            int index = 0;
            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return array;
        }
    }
}

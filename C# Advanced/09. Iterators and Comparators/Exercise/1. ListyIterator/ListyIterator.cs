using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] list)
        {
            this.list = list.ToList();
            index = 0;
        }
        public ListyIterator()
        {

        }
        public bool Move()
        {
            if (index != list.Count)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (index != list.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            try
            {
                Console.WriteLine(list[index]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Operation!");


            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _5._Generic_Count_Method_Strings
{
    public class Box<T> where T:IComparable<T>
    {
        public List<T> Items { get; set; }
        public Box(List<T> items)
        {
            Items = items;
        }
        public void Add(T item)
        {
            Items.Add(item);
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


        public int Compare([AllowNull] T other)
        {
            int count = 0;
            foreach (var item in Items)
            {
                if (item.CompareTo(other)>0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

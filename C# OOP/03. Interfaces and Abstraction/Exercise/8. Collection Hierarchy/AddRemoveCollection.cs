using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Collection_Hierarchy
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        List<string> list;
        public AddRemoveCollection()
        {
            list = new List<string>();
        }
        public int Add(string text)
        {
            if (list.Count >= 1)
            {
                List<string> tmp = new List<string>();
                tmp.Add(text);
                tmp.AddRange(list);
                list = tmp;
            }
            else
            {
                list.Add(text);

            }
            return 0;
        }

        public string Remove()
        {
            string element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }
    }
}

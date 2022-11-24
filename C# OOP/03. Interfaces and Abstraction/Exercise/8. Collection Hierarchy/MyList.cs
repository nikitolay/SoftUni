using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Collection_Hierarchy
{
    public class MyList : IAddable, IRemovable
    {
        List<string> list;
        public MyList()
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
            string element = list[0];
            list.RemoveAt(0);
            return element;
        }
        public List<string> Used => list;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Collection_Hierarchy
{
    public class AddCollection : IAddable
    {
        List<string> list;
        public AddCollection()
        {
            list = new List<string>();
        }
        public int Add(string text)
        {
            list.Add(text);
            return list.Count - 1;
        }
    }
}

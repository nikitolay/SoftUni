using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> list;
        private Random random;
        public RandomList()
        {
            list = new List<string>();
            random = new Random();
        }
        public string RandomString()
        {
            int indexOfRemove = random.Next(0, list.Count);
            string textToRemove = list[indexOfRemove];
            list.RemoveAt(indexOfRemove);
            return textToRemove;

        }
    }
}

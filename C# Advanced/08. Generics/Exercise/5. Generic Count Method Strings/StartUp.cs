using System;
using System.Collections.Generic;

namespace _5._Generic_Count_Method_Strings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            Box<string> box = new Box<string>(list);
            string text = Console.ReadLine();
            Console.WriteLine(box.Compare(text));
        }
    }
}

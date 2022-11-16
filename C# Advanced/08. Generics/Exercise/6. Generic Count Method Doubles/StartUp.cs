using System;
using System.Collections.Generic;

namespace _6._Generic_Count_Method_Doubles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }
            Box<double> box = new Box<double>(list);
            double text = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Compare(text));
        }
    }
}

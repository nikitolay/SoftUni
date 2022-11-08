using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityForDay = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine(orders.Max());
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders.Peek() <= quantityForDay)
                {
                    quantityForDay -= orders.Peek();
                    orders.Dequeue();
                    i--;
                }
            }
            if (orders.Count <= 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}

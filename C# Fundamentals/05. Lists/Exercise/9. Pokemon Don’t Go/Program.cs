using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            while (list.Count > 0)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    int last = list.Last();
                    sum += list[0];
                    int remove = list[0];
                    list.RemoveAt(0);

                    list.Insert(0, last);
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] <= remove)
                        {
                            list[j] += remove;
                        }
                        else if (list[j] > remove)
                        {
                            list[j] -= remove;
                        }
                    }
                    continue;
                }
                else if (n > list.Count - 1)
                {
                    int first = list.First();
                    sum += list[list.Count - 1];
                    int remove = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);

                    list.Add(first);
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] <= remove)
                        {
                            list[j] += remove;
                        }
                        else if (list[j] > remove)
                        {
                            list[j] -= remove;
                        }
                    }
                    continue;
                }

                int removed = list[n];
                sum += list[n];
                list.RemoveAt(n);
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] <= removed)
                    {
                        list[j] += removed;
                    }
                    else if (list[j] > removed)
                    {
                        list[j] -= removed;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}

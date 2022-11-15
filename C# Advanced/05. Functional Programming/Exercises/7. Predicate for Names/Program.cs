using System;
using System.Linq;

namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> IsLessorThan = (x, y) => x.Length <= y;
            Console.WriteLine(string.Join("\n", names.Where(x => IsLessorThan(x, n))));
        }
    }
}

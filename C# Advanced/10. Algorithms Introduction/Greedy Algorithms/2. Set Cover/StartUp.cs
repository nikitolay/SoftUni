namespace _2._Set_Cover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            List<int[]> sets = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] set = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sets.Add(set);
            }
            List<int[]> result = ChooseSets(sets, universe);
            Console.WriteLine($"Sets to take ({result.Count()}):");
            foreach (var item in result)
            {
                Console.WriteLine($"{{ {string.Join(", ", item)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {

            List<int[]> result = new List<int[]>();
            while (sets.Count > 0 && universe.Count > 0)
            {
                int[] current = sets.OrderByDescending(x => x.Count(x => universe.Contains(x))).FirstOrDefault();
                foreach (var item in current)
                {
                    if (universe.Contains(item))
                    {
                        universe.Remove(item);
                    }
                }
                result.Add(current);
            }

            return result;
        }
    }
}

namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());
            var result = ChooseCoins(coins, n);
            Console.WriteLine($"Number of coins to take: {result.Sum(x => x.Value)}");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins=coins.OrderByDescending(x => x).ToList();
            Dictionary<int, int> coinCount = new Dictionary<int, int>();
            int index = coins.Count - 1;
            while (index >= 0)
            {
                int currentCoin = coins[index];
                index--;
                int result = targetSum / currentCoin;
                if (result <= 0)
                {
                    continue;
                }
                coinCount.Add(currentCoin, 0);
                coinCount[currentCoin] += result;
                targetSum -= result * currentCoin;
            }


            if (targetSum > 0)
            {
                throw new InvalidOperationException("Error");
            }

            return coinCount;
        }
    }
}
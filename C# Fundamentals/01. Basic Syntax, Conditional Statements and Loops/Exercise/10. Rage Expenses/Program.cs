using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostCount = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double result = 0;
            int indexx = 1;
            for (int i = 1; i <= lostCount; i++)
            {
                int n = 0;
                if (i % 2 == 0)
                {
                    result += headSetPrice;
                    n += 1;

                }

                if (i % 3 == 0)
                {
                    result += mousePrice;
                    n += 1;
                }
                if (n == 2)
                {

                    result += keyboardPrice;
                    if (indexx % 2 == 0)
                    {

                        result += displayPrice;

                    }
                    indexx++;
                }
            }
            Console.WriteLine($"Rage expenses: {result:f2} lv.");
        }
    }
}

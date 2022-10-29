using System;

namespace _5._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            int sumOfOneAndTwo = SumOfOneAndTwo(one, two);
            int subtractOfThirdFromOneAndTwosUM = SubtractOfThirdFromOneAndTwosUM(three, sumOfOneAndTwo);
            Console.WriteLine(subtractOfThirdFromOneAndTwosUM);
        }

        private static int SubtractOfThirdFromOneAndTwosUM(int three, int sumOfOneAndTwo)
        {
            return sumOfOneAndTwo - three;
        }

        private static int SumOfOneAndTwo(int one, int two)
        {
            return one + two;
        }
    }
}

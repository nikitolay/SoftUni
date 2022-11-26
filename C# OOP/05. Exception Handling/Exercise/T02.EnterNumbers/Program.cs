using System;

namespace T02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                try
                {

                    int num = ReadNumber(1, 100);
                    int lastNumber = array.Length > 0 ? array[i - 1] : 1;

                    if (num > lastNumber && num < 100)
                    {
                        array[i] = num;
                    }
                    else
                    {
                        i--;
                        throw new ArgumentException($"Your number is not in range {lastNumber} - 100!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(string.Join(" ", array));
        }
        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num))
            {

                throw new ArgumentException("Invalid Number!");
            }
            return num;
        }
    }
}

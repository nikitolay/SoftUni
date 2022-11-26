using System;

namespace T05.Convert_ToDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                try
                {

                    string input = Console.ReadLine();
                    double result = Convert.ToDouble(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);

                }

            }

        }
    }
}

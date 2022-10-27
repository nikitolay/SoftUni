using System;

namespace _8._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double resultMaxVolume = double.MinValue;
            string nameResult=string.Empty;
            for (int i = 0; i < n; i++)
            {
                string modoel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                   double result = Math.PI * Math.Pow(radius, 2) * height;
                if (result> resultMaxVolume)
                {
                    resultMaxVolume=result;
                    nameResult = modoel;
                }

            }
            Console.WriteLine(nameResult);
        }
    }
}

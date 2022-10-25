using System;

namespace _9._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightSaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());
            
            int countOfBelts = countOfStudents / 6;

            int currentCountOfStudents=(int)Math.Ceiling(countOfStudents * 1.10);
            double result= currentCountOfStudents * priceOfLightSaber
                +countOfStudents*priceOfRobe
                +(countOfStudents-countOfBelts)*priceOfBelt;
            result = Math.Ceiling(result);
            if (amount<result)
            {
                Console.WriteLine($"John will need {result-amount:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {result:f2}lv.");
            }




        }
    }
}

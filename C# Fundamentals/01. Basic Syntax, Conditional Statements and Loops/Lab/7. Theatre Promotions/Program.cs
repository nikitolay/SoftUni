using System;

namespace _7._Theatre_Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            double result = 0;
            bool isInvalid = false;
            switch (day)
            {
                case "weekday":
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                    {
                        result = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        result = 18;
                    }
                    else
                    {
                        isInvalid = true;
                    }
                    break;
                case "weekend":
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                    {
                        result = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        result = 20;
                    }
                    else
                    {
                        isInvalid = true;
                    }
                    break;
                case "holiday":
                    if (age >= 0 && age <= 18)
                    {
                        result = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        result = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        result = 10;

                    }
                    else
                    {
                        isInvalid = true;
                    }
                    break;
                default:

                    break;
            }
            if (isInvalid)
            {

                Console.WriteLine("Error!");
            }
            else
            {

                Console.WriteLine($"{result}$");
            }
        }
    }
}

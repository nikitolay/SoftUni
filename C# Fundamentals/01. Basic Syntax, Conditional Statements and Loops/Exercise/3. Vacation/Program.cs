using System;

namespace _3._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;

            switch (type)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = n * 8.45;
                            break;
                        case "Saturday":
                            price = n * 9.80;
                            break;
                        case "Sunday":
                            price = n * 10.46;
                            break;
                    }
                    if (n >= 30)
                    {
                        price = price * 0.85;
                    }
                    break;
                case "Business":
                    if (n >= 100)
                    {
                        n -= 10;
                    }
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = n * 10.90;
                            break;
                        case "Saturday":
                            price = n * 15.60;
                            break;
                        case "Sunday":
                            price = n * 16;
                            break;
                    }

                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = n * 15;
                            break;
                        case "Saturday":
                            price = n * 20;
                            break;
                        case "Sunday":
                            price = n * 22.50;
                            break;
                    }
                    if (n >= 10 && n <= 20)
                    {
                        price = price * 0.95;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}

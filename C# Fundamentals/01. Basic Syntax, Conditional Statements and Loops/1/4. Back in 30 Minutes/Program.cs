using System;

namespace _4._Back_in_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours=int.Parse(Console.ReadLine());
            int minutes=int.Parse(Console.ReadLine())+30;
            if (minutes>60)
            {
                hours++;
                if (hours>=24)
                {
                    hours -= 24;
                }
                minutes -= 60;
            }
            if (minutes < 10)
            {

                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                    
            Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}

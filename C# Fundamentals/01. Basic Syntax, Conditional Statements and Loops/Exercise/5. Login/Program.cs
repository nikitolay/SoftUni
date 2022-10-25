using System;
using System.Linq;

namespace _5._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var username = Console.ReadLine();
            var password = Console.ReadLine();

            int count = 1;
           
            var isEquals = password.SequenceEqual(username.Reverse());
            while (!isEquals)
            {
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
                isEquals = password.SequenceEqual(username.Reverse());
                count++;
                if (count>3)
                {
                    Console.WriteLine($"User {username.ToString()} blocked!");
                    return;
                }
            }
            Console.WriteLine($"User {username.ToString()} logged in.");

        }
    }
}

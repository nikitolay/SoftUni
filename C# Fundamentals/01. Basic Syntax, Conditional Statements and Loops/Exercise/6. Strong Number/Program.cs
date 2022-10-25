using System;
using System.Security.Cryptography.X509Certificates;

namespace _6._Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            long n = long.Parse(Console.ReadLine());
            long factN = Factoriel(n);
            if (n== factN)
            {
            Console.WriteLine("yes");

            }
            else
            {
                Console.WriteLine("no");
            }


             long Factoriel(long n)
            {
                if (n==1)
                {
                    return 1;
                }
                return n *Factoriel(n -1);
            }
        }
    }
}

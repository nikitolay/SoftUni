using System;

namespace _4._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = 0;
            int n2 = 1;
            int n3 = 1;
            int n4;
            int number = int.Parse(Console.ReadLine());
            Console.Write(n2 + " " + n3 + " "); //printing 0 and 1    
            for (int i = 3; i <= number; ++i) //loop starts from 2 because 0 and 1 are already printed    
            {
                n4 = n1 + n2 + n3;
                Console.Write(n4 + " ");
                n1 = n2;
                n2 = n3;
                n3 = n4;
            }
        }

    }
}

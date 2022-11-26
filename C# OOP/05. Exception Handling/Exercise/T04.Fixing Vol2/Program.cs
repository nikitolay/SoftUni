﻿using System;

namespace T04.Fixing_Vol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;
            firstNumber = 30;
            secondNumber = 60;
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");

            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

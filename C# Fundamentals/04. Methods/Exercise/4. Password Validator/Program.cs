using System;

namespace _4._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            PasswordValidator(password);
        }

        private static void PasswordValidator(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            int digitCount = 0;
            bool isConsistLetterAndDigits = true;
            for (int i = 0; i < password.Length; i++)
            {
                char current = password[i];
                if (!(char.IsLetter(current) || char.IsDigit(current)))
                {
                    isValid = false;
                    isConsistLetterAndDigits = false;
                }
                if (char.IsDigit(current))
                {
                    digitCount++;
                }
            }
            if (!isConsistLetterAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");

            }
            if (digitCount < 2)
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }

        }
    }
}

using System;

namespace _09.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            int digitCounter = 0;
            int errorCounter = 0;
            errorCounter = CheckPasswordLenght(password, errorCounter);

            CheckForLettersOrDigits(password, ref digitCounter, ref errorCounter);
            errorCounter = CheckAtLeastTwoDigits(digitCounter, errorCounter);
            CkeckForValidPassword(errorCounter);
        }

        private static void CkeckForValidPassword(int errorCounter)
        {
            if (errorCounter == 0)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static int CheckAtLeastTwoDigits(int digitCounter, int errorCounter)
        {
            if (digitCounter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                errorCounter++;
            }

            return errorCounter;
        }

        private static void CheckForLettersOrDigits(string password, ref int digitCounter, ref int errorCounter)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char current = password[i];

                if (char.IsLetterOrDigit(current))
                {
                    if (char.IsDigit(current))
                    {
                        digitCounter++;
                    }
                }
                else
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    errorCounter++;
                    break;
                }
            }
        }

        private static int CheckPasswordLenght(string password, int errorCounter)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                errorCounter++;
            }

            return errorCounter;
        }
    }
}

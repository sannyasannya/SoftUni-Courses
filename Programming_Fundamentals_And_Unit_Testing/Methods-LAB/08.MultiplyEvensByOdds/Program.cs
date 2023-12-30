using System;

namespace _08.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int oddSum = 0;
            int evenSum = 0;

            int num = int.Parse(number);
            num = Math.Abs(num);

            for (int i = 0; i < number.Length; i++)
            {
                int lastDigit = num % 10;
                num = num / 10;
                evenSum = GetSumOfEvenDigits(evenSum, lastDigit);

                oddSum = GetSumOfOddDigits(oddSum, lastDigit);

            }
            int totaSum = GetMultipleOfEvenAndOdds(oddSum, evenSum);
            Console.WriteLine(totaSum);

        }

        private static int GetMultipleOfEvenAndOdds(int oddSum, int evenSum)
        {
            return Math.Abs(oddSum * evenSum);
        }

        private static int GetSumOfOddDigits(int oddSum, int lastDigit)
        {
            if (lastDigit % 2 == 1)
            {
                oddSum += lastDigit;
            }

            return oddSum;
        }

        private static int GetSumOfEvenDigits(int evenSum, int lastDigit)
        {
            if (lastDigit % 2 == 0)
            {
                evenSum += lastDigit;
            }

            return evenSum;
        }
    }
}

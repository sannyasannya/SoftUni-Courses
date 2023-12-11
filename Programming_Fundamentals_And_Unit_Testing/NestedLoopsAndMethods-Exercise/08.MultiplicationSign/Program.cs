using System;

namespace _08.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int negativeCounter = 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            negativeCounter = CheckNumberIsNegative(num1, negativeCounter);
            negativeCounter = CheckNumberIsNegative(num2, negativeCounter);
            negativeCounter = CheckNumberIsNegative(num3, negativeCounter);

            PrintResult(negativeCounter);

        }

        private static void PrintResult(int negativeCounter)
        {
            if (negativeCounter % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }

        private static int CheckNumberIsNegative(int num, int negativeCounter)
        {
            if (num < 0)
            {
                negativeCounter++;
            }

            return negativeCounter;
        }
    }
}

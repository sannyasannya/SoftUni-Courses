using System;

namespace _06._1ProductOfThreeNum
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            int countOfNegative = 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                if (num1 < 0)
                {
                    countOfNegative++;
                }

                if (num2 < 0)
                {
                    countOfNegative++;
                }
                if (num3 < 0)
                {
                    countOfNegative++;
                }

                if (countOfNegative % 2 == 0)
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }
            }
        }
    }
}

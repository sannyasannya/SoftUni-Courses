using System;

namespace _02.MagicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int product = 1;

            //for (int num1 = 1; num1 <= 9; num1++)
            //{
            //    for (int num2 = 0; num2 <= 9; num2++)
            //    {
            //        for (int num3 = 0; num3 <= 9; num3++)
            //        {
            //            if (num1 * num2 * num3 == number)
            //            {
            //                Console.Write($"{num1}{num2}{num3} ");
            //            }
            //        }
            //    }
            //}

            for (int i = 100; i <= 999; i++)
            {
                 int current = i;

                while (current != 0)
                {
                    int lastDigit = current % 10;
                    current = current / 10;
                    product *= lastDigit;

                }

                if (product == number)
                {
                    Console.Write($"{i} ");
                }
                else
                {
                    product = 1;
                }
            }



        }
    }
}

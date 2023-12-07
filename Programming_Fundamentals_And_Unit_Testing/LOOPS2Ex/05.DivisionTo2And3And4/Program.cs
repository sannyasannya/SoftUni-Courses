using System;

namespace _05.DivisionTo2And3And4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            for (int i = 1; i <= num; i++)
            {
               int currentNum = int.Parse(Console.ReadLine());

                if (currentNum % 2 == 0)
                {
                    count2++;
                }

                if (currentNum % 3 == 0)
                {
                    count3++;
                }

                if (currentNum % 4 == 0)
                {
                    count4++;
                }
            }

            double result1 = ((double)count2 / num) * 100;
            double result2 = ((double)count3 / num) * 100;
            double result3 = ((double)count4 / num) * 100;

            Console.WriteLine($"{result1:f2}%");
            Console.WriteLine($"{result2:f2}%");
            Console.WriteLine($"{result3:f2}%");


        }
    }
}

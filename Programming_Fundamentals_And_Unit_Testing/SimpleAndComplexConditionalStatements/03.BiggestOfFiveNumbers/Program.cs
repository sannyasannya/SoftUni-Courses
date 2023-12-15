using System;

namespace _03.BiggestOfFiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num1 = int.Parse(Console.ReadLine());
            //int num2 = int.Parse(Console.ReadLine());
            //int num3 = int.Parse(Console.ReadLine());
            //int num4 = int.Parse(Console.ReadLine());
            //int num5 = int.Parse(Console.ReadLine());

            //int maxNum = int.MinValue;

            //if (num1 > maxNum)
            //{
            //    maxNum = num1;
            //}

            //if (num2 > maxNum)
            //{
            //    maxNum = num2;
            //}

            //if (num3 > maxNum)
            //{
            //    maxNum = num3;
            //}

            //if (num4 > maxNum)
            //{
            //    maxNum = num4;
            //}

            //if (num5 > maxNum)
            //{
            //    maxNum = num5;
            //}

            //Console.WriteLine(maxNum);
            int maxNum = int.MinValue;

            for (int i = 0; i < 5; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > maxNum)
                {
                    maxNum = num;
                }
            }

            Console.WriteLine(maxNum);
            
        }
    }
}

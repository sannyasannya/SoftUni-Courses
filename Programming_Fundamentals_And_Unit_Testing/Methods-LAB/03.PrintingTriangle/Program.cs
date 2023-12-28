using System;

namespace _03.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTriangle(num);
        }

        private static void PrintTriangle(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                PrintLine(i);
            }

            for (int i = num - 1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        private static void PrintLine(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} ");
            }

            Console.WriteLine();
        }

    }
}

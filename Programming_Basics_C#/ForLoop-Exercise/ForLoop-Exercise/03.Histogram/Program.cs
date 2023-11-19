﻿namespace _03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    p1++;
                }
                else if (currentNumber < 400)
                {
                    p2++;
                }
                else if (currentNumber < 600)
                {
                    p3++;
                }
                else if (currentNumber < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            Console.WriteLine($"{(double)p1 / n * 100:f2}%");
            Console.WriteLine($"{(double)p2 / n * 100:f2}%");
            Console.WriteLine($"{(double)p3 / n * 100:f2}%");
            Console.WriteLine($"{(double)p4 / n * 100:f2}%");
            Console.WriteLine($"{(double)p5 / n * 100:f2}%");

        }
    }
}
using System;

namespace _05.HappyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= number; d1++)
            {
                for (int d2 = 0; d2 <= number; d2++)
                {
                    for (int d3 = 0; d3 <= number; d3++)
                    {
                        for (int d4 = 0; d4 <= number; d4++)
                        {
                            if ((d1 + d2 == number) && (d3 + d4 == number))
                            {
                                Console.Write($"{d1}{d2}{d3}{d4} ");
                            }
                        }
                    }
                }
            }
        }
    }
}

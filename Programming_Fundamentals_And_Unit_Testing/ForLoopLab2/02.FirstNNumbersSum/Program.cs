using System;

namespace _02.FirstNNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= num; i++)
            {
                if (i == 1)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write($"+{i}");
                }

                sum += i;  
            }

            Console.WriteLine($"={sum}");
        }
    }
}

using System;

namespace _07.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int result = 0;

            for (int i = 0; i < num; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                result += currentNumber;
            }
            Console.WriteLine(result);
        }
    }
}

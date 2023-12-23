using System;
using System.Linq;

namespace _02.SumAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                               .Split(" ")
                               .Select(int.Parse)
                               .ToArray();

            int sum = 0;
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);

        }
    }
}

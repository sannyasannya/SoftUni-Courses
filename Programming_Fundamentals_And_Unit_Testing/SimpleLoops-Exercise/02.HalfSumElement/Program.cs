using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber = int.MinValue;

            for (int i = 0; i < number; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > maxNumber)
                {
                    maxNumber = num;
                }

            }
            int sumWithoutMaxNumber = sum - maxNumber;
            if (maxNumber == sumWithoutMaxNumber)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sumWithoutMaxNumber}");
            }
            else
            {
                int diff = Math.Abs(maxNumber - sumWithoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}

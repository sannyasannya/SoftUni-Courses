using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[4];

            numbers[0] = 2;
            numbers[1] = 10;
            numbers[2] = 12;
            numbers[3] = 25;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}

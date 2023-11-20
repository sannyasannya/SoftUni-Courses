using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int sum = 0;
            
            while (number1 > sum)
            {
                int number2 = int.Parse(Console.ReadLine());
                sum += number2;
            }

            Console.WriteLine(sum);
        }
    }
}

using System;

namespace _07.SumOfDigitsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;

            while (number != "End")
            {
                int digit = int.Parse(number);
               

                while (digit != 0)
                {
                    int lastDigt = digit % 10;
                    sum += lastDigt;
                    digit = digit / 10;                   
                    
                }

                Console.WriteLine($"Sum of digits = {sum}");
                sum = 0;
                number = Console.ReadLine();

            }
            Console.WriteLine("Goodbye");
        }
    }
}

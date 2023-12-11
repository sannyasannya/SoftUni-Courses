using System;

namespace _07.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());

            long factorial1 = num1;
            long factorial2 = num2;

            factorial1 = CalculateFactorial(num1, factorial1);
            factorial2 = CalculateFactorial(num2, factorial2);

            long division = factorial1 / factorial2;
            Console.WriteLine(division);
        }

        private static long CalculateFactorial(long num, long factorial)
        {
            for (long i = num - 1; i >= 1; i--)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}

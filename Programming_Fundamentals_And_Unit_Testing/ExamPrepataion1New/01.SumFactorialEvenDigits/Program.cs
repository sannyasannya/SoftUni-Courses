namespace _01.SumFactorialEvenDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int result = int.Parse(Console.ReadLine());

            int sumOfFactorial = 0;

            while (result != 0)
            {
                int digit = result % 10;

                if (digit % 2 == 0)
                {
                    int resultFactorial = CalculateFactorial(digit);
                    sumOfFactorial += resultFactorial;
                }
                result = result / 10;
            }
            Console.WriteLine(sumOfFactorial);
        }

        static int CalculateFactorial(int number)
        {
            int result = 1;

            while (number > 0)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
using System;

namespace _06.ProductOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 * num2 * num3 < 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 * num2 * num3 > 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 * num2 * num3 == 0)
            {
                Console.WriteLine("zero");
            }
        }
    }
}

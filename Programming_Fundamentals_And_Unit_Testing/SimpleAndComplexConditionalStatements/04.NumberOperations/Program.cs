using System;

namespace _04.NumberOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string operat = Console.ReadLine();

            if (operat == "+")
            {
                double sum = num1 + num2;
                Console.WriteLine($"{num1} {"+"} {num2} = {sum:f2}");
            }
            else if (operat == "-")
            {
                double sum = num1 - num2;
                Console.WriteLine($"{num1} {"-"} {num2} = {sum:f2}");
            }
            else if (operat == "*")
            {
                double sum = num1 * num2;
                Console.WriteLine($"{num1} {"*"} {num2} = {sum:f2}");
            }
            else if (operat == "/")
            {
                double sum = num1 / num2;
                Console.WriteLine($"{num1} {"/"} {num2} = {sum:f2}");
            }
        }
    }
}

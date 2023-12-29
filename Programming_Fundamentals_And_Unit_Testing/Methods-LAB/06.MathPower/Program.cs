using System;

namespace _06.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = MathPower(number, power);
            Console.WriteLine(result);
        }
        static double MathPower(double number, double power)
        {
            double output = Math.Pow(number, power);
            
            return output;

        }
    }
}

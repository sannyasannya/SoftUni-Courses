using System;

namespace _04.InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double lenght = a * 2.54;

            Console.WriteLine(lenght);
        }
    }
}

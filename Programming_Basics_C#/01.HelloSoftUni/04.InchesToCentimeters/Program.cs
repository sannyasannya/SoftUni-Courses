using System;

namespace _04.InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double inches = num * 2.54;
            Console.WriteLine(inches);
        }
    }
}

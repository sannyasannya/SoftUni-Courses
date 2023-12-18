using System;

namespace _10.ValidTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double sideC = double.Parse(Console.ReadLine());

            if (sideA >= sideB + sideC)
            {
                Console.WriteLine("Invalid Triangle");
            }
            else if (sideB >= sideA + sideC)
            {
                Console.WriteLine("Invalid Triangle");
            }
            else if (sideC >= sideA + sideB)
            {
                Console.WriteLine("Invalid Triangle");
            }
            else
            {
                Console.WriteLine("Valid Triangle");    
            }
        }
    }
}

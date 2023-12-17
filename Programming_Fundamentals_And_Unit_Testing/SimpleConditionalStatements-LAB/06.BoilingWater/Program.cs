using System;

namespace _06.BoilingWater
{
    class Program
    {
        static void Main(string[] args)
        {
            double temperature = double.Parse(Console.ReadLine());

            if (temperature > 100)
            {
                Console.WriteLine($"The water is boiling");
            }
            else
            {
                Console.WriteLine($"The water is not hot enough");
            }
        }
    }
}

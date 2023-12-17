using System;

namespace SimpleConditionalStatements_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            double temperatute = double.Parse(Console.ReadLine());

            if (temperatute <= 0)
            {
                Console.WriteLine($"Freezing weather!");
            }
        }
    }
}

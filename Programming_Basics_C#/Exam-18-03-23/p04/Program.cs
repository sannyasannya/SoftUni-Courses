using System;

namespace p04
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double startingKm = double.Parse(Console.ReadLine());
            double kmCounter = startingKm;

            for (int i = 0; i < days; i++)
            {
                int percent = int.Parse(Console.ReadLine());
                startingKm = startingKm +((percent * startingKm) / 100);
                kmCounter += startingKm;
            }

            if (kmCounter >= 1000)
            {
                double moreKm = Math.Ceiling(kmCounter - 1000);
                Console.WriteLine($"You've done a great job running {moreKm} more kilometers!");
            }
            else
            {
                double requiredKm = Math.Ceiling(1000 - kmCounter);
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {requiredKm} more kilometers");
            }
        }
    }
}

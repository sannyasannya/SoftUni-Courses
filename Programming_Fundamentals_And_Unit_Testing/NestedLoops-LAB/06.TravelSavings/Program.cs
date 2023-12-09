using System;

namespace _06.TravelSavings
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            double sum = 0;

            while (sum <= budget)
            {
                int currentSum = int.Parse(Console.ReadLine());
                
                while (destination != "End")
                {
                    if (sum >= budget)
                    {
                        sum += currentSum;
                        Console.WriteLine($"Collected: {sum:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"Going to {destination}");
                        break;
                    }
                }
                destination = Console.ReadLine();
                budget = int.Parse(Console.ReadLine());
                
            }
            Console.WriteLine($"Going to {destination}");
        }
    }
}

using System;

namespace _06._1TravelSaving
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();            

            while (destination != "End")
            {
                double neededMoney = double.Parse(Console.ReadLine());
                double sum = 0;

                while (sum < neededMoney)
                {
                    double currentSum = double.Parse(Console.ReadLine());
                    sum += currentSum;
                    Console.WriteLine($"Collected: {sum:f2}");
                }

                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();

            }


        }
    }
}

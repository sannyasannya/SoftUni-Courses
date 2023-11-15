using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ramMemory = int.Parse(Console.ReadLine());

            double videoCardsPrice = videoCards * 250;

            double processorsPrice = videoCardsPrice * 0.35;
            double processorsCosts = processors * processorsPrice;

            double ramMemoryPrice = videoCardsPrice * 0.10;
            double ramMemoryCosts = ramMemory * ramMemoryPrice;

            double totalCosts = videoCardsPrice + processorsCosts + ramMemoryCosts;

            if (videoCards > processors)
            {
                totalCosts = totalCosts - 0.15 * totalCosts;
            }
            if (budget >= totalCosts)
            {
                double remainingMoney = budget - totalCosts;
                Console.WriteLine($"You have {remainingMoney:f2} leva left!");
            }
            else
            {
                double requiredMoney = totalCosts - budget;
                Console.WriteLine($"Not enough money! You need {requiredMoney:f2} leva more!");
            }
        }
    }
}

using System;

namespace _03.NewHome
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double finalPrice = 0.0;

            if (flowersType == "Roses")
            {
                finalPrice  = flowerCount * 5;
               
                if (flowerCount > 80)
                {
                    finalPrice = finalPrice - (finalPrice * 0.1);                   
                }
            }
            else if (flowersType == "Dahlias")
            {
                finalPrice = flowerCount * 3.8;

                if (flowerCount > 90)
                {
                    finalPrice = finalPrice - (finalPrice * 0.15);
                }
            }
            else if (flowersType == "Tulips")
            {
                finalPrice= flowerCount * 2.8;

                if (flowerCount > 80)
                {
                    finalPrice = finalPrice - (finalPrice * 0.15);                   
                }
            }
            else if (flowersType == "Narcissus")
            {
                finalPrice = flowerCount * 3;

                if (flowerCount < 120)
                {
                    finalPrice = finalPrice + (finalPrice * 0.15);
                }
            }
            else if (flowersType == "Gladiolus")
            {
                finalPrice = flowerCount * 2.5;

                if (flowerCount < 80)
                {
                    finalPrice *= 1.2;
                }
            }

            if (budget >= finalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowersType} and {(budget - finalPrice):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(finalPrice - budget):f2} leva more.");
            }


        }
    }
}

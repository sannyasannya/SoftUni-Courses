using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());
            double price = 0;
            

            if (season == "Spring")
            {
                price = 3000;

                if (fishermenCount <= 6)
                {
                     price = price - (price * 0.1);
                }
                else if (fishermenCount <= 11)
                {
                    price = price - (price * 0.15);
                }
                else if (fishermenCount >= 12)
                {
                   price = price - (price * 0.25);
                }

                if (fishermenCount % 2 == 0)
                {
                    price = price - (price * 0.05);
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200;

                if (fishermenCount <= 6)
                {
                    price = price - (price * 0.1);
                }
                else if (fishermenCount <= 11)
                {
                    price = price - (price * 0.15);
                }
                else if (fishermenCount >= 12)
                {
                    price = price - (price * 0.25);
                }

                if (fishermenCount % 2 == 0 && season == "Summer")
                {
                    price = price - (price * 0.05);
                }
            }
            else if (season == "Winter")
            {
                price = 2600;

                if (fishermenCount <= 6)
                {
                    price = price - (price * 0.1);
                }
                else if (fishermenCount <= 11)
                {
                    price = price - (price * 0.15);
                }
                else if (fishermenCount >= 12)
                {
                    price = price - (price * 0.25);
                }

                if (fishermenCount % 2 == 0)
                {
                    price = price - (price * 0.05);
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(price - budget):f2} leva.");
            }


        }
    }
}

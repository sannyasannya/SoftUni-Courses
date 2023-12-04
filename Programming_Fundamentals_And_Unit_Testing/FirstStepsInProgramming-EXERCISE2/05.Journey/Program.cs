using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = string.Empty;
            double price = 0;
            string holidayType = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    price = budget - (budget * 0.3);
                    holidayType = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget - (budget * 0.7);
                    holidayType = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    price = budget - (budget * 0.4);
                    holidayType = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget - (budget * 0.8);
                    holidayType = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";

                if (season == "summer")
                {
                    price = budget - (budget * 0.9);
                    holidayType = "Hotel";
                }
                else if (season == "winter")
                {
                    price = budget - (budget * 0.9);
                    holidayType = "Hotel";
                }
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {(budget - price):f2}");

        }
    }
}

using System;

namespace p03
{
    class Program
    {
        static void Main(string[] args)
        {

            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double priceNight = 0;


            if (roomType == "room for one person")
            {
                priceNight = 18;

            }
            else if (roomType == "apartment")
            {
                priceNight = 25;

                if (days < 10)
                {
                    priceNight = priceNight - priceNight * 0.3;
                }
                else if (days > 10 && days < 15)
                {
                    priceNight = priceNight - priceNight * 0.35;
                }
                else
                {
                    priceNight = priceNight - priceNight * 0.5;
                }
            }
            else if (roomType == "president apartment")
            {
                priceNight = 35;

                if (days < 10)
                {
                    priceNight = priceNight - priceNight * 0.1;
                }
                else if (days > 10 && days < 15)
                {
                    priceNight = priceNight - priceNight * 0.15;
                }
                else
                {
                    priceNight = priceNight - priceNight * 0.2;
                }
            }

            double totalPriceNight = days * priceNight;
            double totalPrice = totalPriceNight - priceNight;
            double priceForStay = 0;

            if (rating == "positive")
            {
                priceForStay = totalPrice + 0.25 * totalPrice;
                Console.WriteLine($"{priceForStay:f2}");
            }
            else if (rating == "negative")
            {
                priceForStay = totalPrice - 0.1 * totalPrice;
                Console.WriteLine($"{priceForStay:f2}");
            }
        }
    }
    
}

using System;

namespace _09.SkiHoliday
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string assessment = Console.ReadLine();

            double roomPrice = 0;
            double apartmentPrice = 0;
            double prAppartment = 0;
            double nightPrice = 0;

            if (type == "room for one person")
            {
                roomPrice = 118;
                nightPrice = (days - 1) * roomPrice;


            }
            else if (type == "apartment")
            {
                apartmentPrice = 155;
                nightPrice = (days - 1) * apartmentPrice;

                if (days < 10)
                {
                    nightPrice *= 0.7;
                }
                else if (days <= 15)
                {
                    nightPrice *= 0.65;
                }
                else if (days > 15)
                {
                    nightPrice *= 0.5;
                }
            }
            else if (type == "president apartment")
            {
                prAppartment = 235;
                nightPrice = (days - 1) * prAppartment;


                if (days < 10)
                {
                    nightPrice *= 0.9;
                }
                else if (days <= 15)
                {
                    nightPrice *= 0.85;
                }
                else if (days > 15)
                {
                    nightPrice *= 0.8;
                }
            }


            if (assessment == "positive")
            {
                double totalPrice = nightPrice * 1.25;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (assessment == "negative")
            {
                double totalPrice = nightPrice * 0.9;
                Console.WriteLine($"{totalPrice:f2}");
            }

        }
    }
}

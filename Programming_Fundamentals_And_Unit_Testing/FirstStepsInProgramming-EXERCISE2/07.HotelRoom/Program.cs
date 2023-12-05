using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightCount = int.Parse(Console.ReadLine());            
            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50 * nightCount;

                if (nightCount > 14)
                {
                    studioPrice = studioPrice * 0.7;
                }
                else if (nightCount > 7)
                {
                    studioPrice = studioPrice * 0.95 ;
                }

                apartmentPrice = 65 * nightCount;

                if (nightCount > 14)
                {
                    apartmentPrice = apartmentPrice * 0.9;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.2 * nightCount;

                if (nightCount > 14)
                {
                    studioPrice = studioPrice * 0.8;
                }

                apartmentPrice = 68.7 * nightCount;

                if (nightCount > 14)
                {
                    apartmentPrice = apartmentPrice * 0.9;
                }
            }
            else if (month == "July" || month == "August")
            {                                
                studioPrice = 76 * nightCount;              
                apartmentPrice = 77 * nightCount;

                if (nightCount > 14)
                {
                    apartmentPrice = apartmentPrice * 0.9;
                }               
            }           

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}

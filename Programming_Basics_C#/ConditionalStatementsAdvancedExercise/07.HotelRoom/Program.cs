namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;

                if (nightsCount > 14)
                {
                    studioPrice = studioPrice - 0.3 * studioPrice;
                    apartmentPrice = apartmentPrice - 0.1 * apartmentPrice;
                }
                else if (nightsCount > 7)
                {
                    studioPrice = studioPrice - 0.05 * studioPrice;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.2;
                apartmentPrice = 68.7;

                if (nightsCount > 14)
                {
                    studioPrice = studioPrice - 0.2 * studioPrice;
                    apartmentPrice = apartmentPrice - 0.1 * apartmentPrice;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;

                if (nightsCount > 14)
                {
                    apartmentPrice = apartmentPrice - 0.1 * apartmentPrice;
                }
            }
            double totalApertmentPrice = apartmentPrice * nightsCount;
            double totalStudioPrice = studioPrice * nightsCount;

            Console.WriteLine($"Apartment: {totalApertmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");

        }
    }
}

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = string.Empty;
            string holidayType = string.Empty;

            double destinationPrice = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    destinationPrice = 0.3 * budget;
                    holidayType = "Camp";
                }
                else if (season == "winter")
                {
                    destinationPrice = 0.7 * budget;
                    holidayType = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    destinationPrice = 0.4 * budget;
                    holidayType = "Camp";
                }
                else if (season == "winter")
                {
                    destinationPrice = 0.8 * budget;
                    holidayType = "Hotel";
                }
            }
            else
            {
                destination = "Europe";

                destinationPrice = 0.9 * budget;
                holidayType = "Hotel";

            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {destinationPrice:f2}");
        }
    }
}

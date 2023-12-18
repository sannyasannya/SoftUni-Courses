using System;

namespace _08.TicketPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();
            

            if (ticketType == "student")
            {
                double price = 1.00;
                Console.WriteLine($"${price:f2}");
            }
            else if (ticketType == "regular")
            {
                double price = 1.60;
                Console.WriteLine($"${price:f2}");
            }
            else
            {
                Console.WriteLine("Invalid ticket type!");     
            }

        }
    }
}

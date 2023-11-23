using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            string movieName = Console.ReadLine();
            

            while (movieName != "Finish")
            {
                int freePlaces = int.Parse(Console.ReadLine());
                int takenSeats = 0;
                string ticketType = Console.ReadLine();

                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        studentTickets++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTickets++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTickets++;
                    }

                    takenSeats++;

                    if (takenSeats == freePlaces)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                double projectionPercentage = ((double)takenSeats / freePlaces) * 100;

                Console.WriteLine($"{movieName} - {projectionPercentage:f2}% full.");
                movieName = Console.ReadLine();
            }
            double totalSoldTickets = studentTickets + standardTickets + kidTickets;
            Console.WriteLine($"Total tickets: {totalSoldTickets}");
            Console.WriteLine($"{(((double)studentTickets / totalSoldTickets) * 100):f2}% student tickets.");
            Console.WriteLine($"{(((double)standardTickets / totalSoldTickets) * 100):f2}% standard tickets.");
            Console.WriteLine($"{(((double)kidTickets / totalSoldTickets) * 100):f2}% kids tickets.");

        }
    }
}

using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicket = 0;
            int standardTicket = 0;
            int kidTicket = 0;

            string movieName = Console.ReadLine();
            
            while (movieName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                int takenSeats = 0;
                string ticketType = Console.ReadLine();


                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        studentTicket++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTicket++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTicket++;
                    }

                    takenSeats++;
                    if (takenSeats == freeSeats)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();

                }
                double projectionPercentage = ((double)takenSeats / freeSeats) * 100;
                Console.WriteLine($"{movieName} - {projectionPercentage:f2}% full.");


                movieName = Console.ReadLine();

            }

            double totalSoldTickets = studentTicket + standardTicket + kidTicket;
            Console.WriteLine($"Total tickets: {totalSoldTickets}");
            Console.WriteLine($"{(((double)studentTicket / totalSoldTickets) * 100):f2}% student tickets.");
            Console.WriteLine($"{(((double)standardTicket / totalSoldTickets) * 100):f2}% standard tickets.");
            Console.WriteLine($"{(((double)kidTicket / totalSoldTickets) * 100):f2}% kids tickets.");
        }
    }
}

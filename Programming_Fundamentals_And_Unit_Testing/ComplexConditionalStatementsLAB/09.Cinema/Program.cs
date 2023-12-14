using System;

namespace _09.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());

            double price = 0;
            int totalSeats = rows * seats;

            if (movieType == "Premiere")
            {
                price = 12.00;
            }
            else if (movieType == "Normal")
            {
                price = 7.50;
            }
            else if (movieType == "Discount")
            {
                price = 5.00;    
            }

            double totalPrice = totalSeats * price;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

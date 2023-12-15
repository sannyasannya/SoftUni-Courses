using System;

namespace _05.VacationExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string type = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double totalPrice = 0;            

            if (season == "Spring")
            {              

                if (type == "Hotel")
                {
                    totalPrice = 30 * days;
                }
                else if (type == "Camping")
                {
                    totalPrice = 10 * days;
                }
                totalPrice *= 0.8;
            }
            else if (season == "Summer")
            {                

                if (type == "Hotel")
                {
                    totalPrice = 50 * days;
                }
                else if (type == "Camping")
                {
                    totalPrice = 30 * days;
                }
            }
            else if (season == "Autumn")
            {
                
                if (type == "Hotel")
                {
                    totalPrice = 20 * days;
                }
                else if (type == "Camping")
                {
                    totalPrice = 15 * days;
                }
                totalPrice *= 0.7;

            }
            else if (season == "Winter")
            {                

                if (type == "Hotel")
                {
                    totalPrice = 40 * days;
                }
                else if (type == "Camping")
                {
                    totalPrice = 10 * days;
                }

                totalPrice *= 0.9;
            }
            
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

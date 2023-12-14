using System;

namespace ComplexConditionalStatementsLAB
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();            

            if (product == "Banana")
            {
                if (day == "Weekday")
                {
                     double price = 2.50;
                    Console.WriteLine($"{price:f2}");
                }
                else if (day == "Weekend")
                {
                   double price = 2.70;
                    Console.WriteLine($"{price:f2}");
                }
            }
            else if (product == "Apple")
            {
                if (day == "Weekday")
                {
                    double price  = 1.30;
                    Console.WriteLine($"{price:f2}");
                }
                else if (day == "Weekend")
                {
                    double price  = 1.60;
                    Console.WriteLine($"{price:f2}");
                }
            }
            else if (product == "Kiwi")
            {
                if (day == "Weekday")
                {
                    double price  = 2.20;
                    Console.WriteLine($"{price:f2}");
                }
                else if (day == "Weekend")
                {
                    double price  = 3.00;
                    Console.WriteLine($"{price:f2}");
                }
            }
        }
    }
}

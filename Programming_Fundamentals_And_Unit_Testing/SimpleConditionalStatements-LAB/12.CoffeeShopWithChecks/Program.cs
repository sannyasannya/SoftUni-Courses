using System;

namespace _12.CoffeeShopWithChecks
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string extra = Console.ReadLine();

            double price = 0;

            if (drink == "coffee")
            {
                price = 1.00;

                if (extra == "sugar")
                {
                    price += 0.40;
                }
                else if (extra == "no")
                {
                    price += 0;
                }
                else 
                {
                    Console.WriteLine("Unknown extra");
                    return;
                    
                }
               
                Console.WriteLine($"Final price: ${price:f2}");
            }
            else if (drink == "tea")
            {
                price = 0.60;

                if (extra == "sugar")
                {
                    price += 0.40;
                }
                else if (extra == "no")
                {
                    price += 0;
                }
                else 
                {
                    Console.WriteLine("Unknown extra");
                    return;

                }

                Console.WriteLine($"Final price: ${price:f2}");
            }
            else
            {
                Console.WriteLine("Unknown drink");
            }

        }
    }
}

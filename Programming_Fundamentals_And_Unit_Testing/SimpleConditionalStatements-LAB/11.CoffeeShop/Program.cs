using System;

namespace _11.CoffeeShop
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
                Console.WriteLine($"Final price: ${price:f2}");
            }
            else if (drink == "tea")
            {
                price = 0.60;

                if (extra == "sugar")
                {
                    price += 0.40;
                }
                Console.WriteLine($"Final price: ${price:f2}");
            }
            
        }
    }
}

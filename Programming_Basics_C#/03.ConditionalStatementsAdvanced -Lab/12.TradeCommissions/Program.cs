using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double priceCommissions = 0;

            if (town == "sofia")
            {
                if (0 <= sales && sales <= 500 )
                {
                    priceCommissions = 0.05;
                }
                else if ( 500 < sales && sales <= 1000)
                {
                    priceCommissions = 0.07;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    priceCommissions = 0.08;
                }
                else if (sales > 10000)
                {
                    priceCommissions = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }

                double totalPrice = priceCommissions * sales;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (town == "varna")
            {
                if(0 <= sales && sales <= 500)
                {
                    priceCommissions = 0.045;
                }
                else if (500 < sales && sales <= 1000)
                {
                    priceCommissions = 0.075;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    priceCommissions = 0.1;
                }
                else if (sales > 10000)
                {
                    priceCommissions = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }
                double totalPrice = priceCommissions * sales;
                Console.WriteLine($"{totalPrice:f2}");
                
            }
            else if (town == "plovdiv")
            {
                if(0 <= sales && sales <= 500)
                {
                    priceCommissions = 0.055;
                }
                else if (500 < sales && sales <= 1000)
                {
                    priceCommissions = 0.08;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    priceCommissions = 0.12;
                }
                else if (sales > 10000)
                {
                    priceCommissions = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }
                double totalPrice = priceCommissions * sales;
                Console.WriteLine($"{totalPrice:f2}");

            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}

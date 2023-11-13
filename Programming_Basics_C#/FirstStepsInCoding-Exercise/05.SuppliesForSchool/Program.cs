using System;

namespace _05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int cleaningAgent = int.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double penPrice = pens * 5.80;
            double markerPrice = markers * 7.20;
            double cleaningAgentPrice = cleaningAgent * 1.2;

            double priceBeforeDiscount = penPrice + markerPrice + cleaningAgentPrice;
            double totalPrice = priceBeforeDiscount - (priceBeforeDiscount * discountPercentage * 0.01);

            Console.WriteLine(totalPrice);                       
        }
    }
}

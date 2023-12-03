using System;

namespace _05.TeachingMaterials
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int literBoardCleaner = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pricePens = pens * 5.8;
            double priceMarkers = markers * 7.2;
            double priceBoardCleaner = literBoardCleaner * 1.2;
            double totalPrice = pricePens + priceMarkers + priceBoardCleaner;


            double priceAfterDiscount = totalPrice - (totalPrice * discount * 0.01);

            Console.WriteLine(priceAfterDiscount);
        }
    }
}

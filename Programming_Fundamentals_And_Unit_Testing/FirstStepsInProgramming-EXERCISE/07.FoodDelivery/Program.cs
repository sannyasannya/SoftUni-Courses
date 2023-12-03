using System;

namespace _07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegetarianMenu = int.Parse(Console.ReadLine());

            double chickenPrice = chickenMenu * 10.35;
            double fishPrice = fishMenu * 12.40;
            double vegetarianPrice = vegetarianMenu * 8.15;
            double totalPriceMenu = chickenPrice + fishPrice + vegetarianPrice;
            double dessertPrice = totalPriceMenu * 0.2;
            double totalOrderprice = totalPriceMenu + dessertPrice + 2.5;

            Console.WriteLine(totalOrderprice);

        }
    }
}

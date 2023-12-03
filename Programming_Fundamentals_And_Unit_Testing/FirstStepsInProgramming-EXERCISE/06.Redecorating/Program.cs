using System;

namespace _06.Redecorating
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int tinner = int.Parse(Console.ReadLine());
            int neededHour = int.Parse(Console.ReadLine());

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = (paint + (paint * 0.1)) * 14.50;
            double tinnerPrice = tinner * 5;
            double materialPrice = nylonPrice + paintPrice + tinnerPrice + 0.4;
            double craftmanPrice = (materialPrice * 0.3) * neededHour;
            double totalPrice = materialPrice + craftmanPrice;

            Console.WriteLine(totalPrice);
        }
    }
}

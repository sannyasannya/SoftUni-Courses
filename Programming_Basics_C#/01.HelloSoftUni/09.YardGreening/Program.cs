using System;

namespace _09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeter = double.Parse(Console.ReadLine());
            double squareMeterPrice = 7.61;

            double endPrice = squareMeter * squareMeterPrice;
            double discount = endPrice * 0.18;
            double totalEndPrice = endPrice - discount;

            //output
            Console.WriteLine($"The final price is: {totalEndPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
                   
        }
    }
}

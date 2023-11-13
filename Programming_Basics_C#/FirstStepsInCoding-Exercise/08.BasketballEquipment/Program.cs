using System;

namespace _08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int tax = int.Parse(Console.ReadLine());

            double shoesPrice = tax - 0.4 * tax;
            double kitPrice = shoesPrice - 0.2 * shoesPrice;
            double ballPrice = (1.0 / 4) * kitPrice;
            double accessoariesPrice = (1.0 / 5) * ballPrice;

            double total = tax + shoesPrice + kitPrice + ballPrice + accessoariesPrice;

            Console.WriteLine(total);

            

        }
    }
}

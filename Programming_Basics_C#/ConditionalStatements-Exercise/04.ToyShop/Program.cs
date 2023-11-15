using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlesPrice = puzzles * 2.6;
            double dollsPrice = dolls * 3;
            double bearsPrice = bears * 4.1;
            double minionsPrice = minions * 8.2;
            double trucksPrice = trucks * 2;
            
            double totalPrice = puzzlesPrice + dollsPrice + bearsPrice + minionsPrice + trucksPrice;
            double toysCount = puzzles + dolls + bears + minions + trucks;
           
            if (toysCount >= 50)
            {

                double toysDiscount = totalPrice * 0.25;
                totalPrice = totalPrice - toysDiscount;
            }

            double rent = 0.1 * totalPrice;
            double finalPrice = totalPrice - rent;

            if (finalPrice >= tripPrice)
            {
                double remainingMoney = finalPrice - tripPrice;
                Console.WriteLine($"Yes! {remainingMoney:f2} lv left.");
            }
            else
            {
                double requiredMoney = tripPrice - finalPrice;
                Console.WriteLine($"Not enough money! {requiredMoney:f2} lv needed.");                
            }                                                                       
                                                                    
           
        }
    }
}

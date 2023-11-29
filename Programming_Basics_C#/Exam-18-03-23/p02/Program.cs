using System;

namespace p02
{
    class Program
    {
        static void Main(string[] args)
        {
            double partyPrice = double.Parse(Console.ReadLine());
            int loveMessageCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int keyToysCount = int.Parse(Console.ReadLine());
            int caricatureCount = int.Parse(Console.ReadLine());
            int luckSurpriceCount = int.Parse(Console.ReadLine());

           double sum = loveMessageCount * 0.6 + rosesCount * 7.2 + keyToysCount * 3.6 + caricatureCount * 18.2 + luckSurpriceCount * 22;
            int itemCount = loveMessageCount + rosesCount + keyToysCount + caricatureCount + luckSurpriceCount;
            double discountPrice = 0;


            if (itemCount >= 25)
            {
                 discountPrice = sum * 0.35;
            }

            double totalPrice = sum - discountPrice;
            double hosting = totalPrice * 0.1;
            double win = totalPrice - hosting;

            if (win > partyPrice)
            {
                double remainingMoney = win - partyPrice;
                Console.WriteLine($"Yes! {remainingMoney:f2} lv left.");
            }
            else
            {
                double reqiuredMoney = partyPrice - win;
                Console.WriteLine($"Not enough money! {reqiuredMoney:f2} lv needed.");
            }
        }
    }
}

using System;

namespace _08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainingFee = int.Parse(Console.ReadLine());

            double sneakersPrice = trainingFee - (0.4 * trainingFee);
            double teamPrice = sneakersPrice - (0.2 * sneakersPrice);
            double basketballPrice = teamPrice * 0.25;
            double accessories = basketballPrice * 0.2;
            double totalPrice = trainingFee + sneakersPrice + teamPrice + basketballPrice + accessories;

            Console.WriteLine(totalPrice);
        }
    }
}

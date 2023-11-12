using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFoodpacks = int.Parse(Console.ReadLine());
            int catFoodpacks = int.Parse(Console.ReadLine());

            double dogFoodPrice = 2.5;
            double catFoodPrice = 4;

            double totalDogFoodPrice = dogFoodpacks * dogFoodPrice;
            double totalCatFoodPrice = catFoodpacks * catFoodPrice;

            double totalFoodPrice = totalDogFoodPrice + totalCatFoodPrice;

            string result = $"{totalFoodPrice} lv.";

            Console.WriteLine(result);
        }
    }
}

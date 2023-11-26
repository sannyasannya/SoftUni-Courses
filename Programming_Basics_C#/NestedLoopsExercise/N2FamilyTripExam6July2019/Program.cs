using System;

namespace N2FamilyTripExam6July2019
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            decimal nightPrice = decimal.Parse(Console.ReadLine());
            int percentAddExp = int.Parse(Console.ReadLine());


            decimal totalNight = nights * nightPrice;

            if (nights > 7)
            {
                totalNight = totalNight - 0.05m * totalNight;
            }
            
            

            decimal AddPrice = (budget * percentAddExp) / 100;
            decimal totalExp = AddPrice + totalNight;
            decimal remainingMoney = budget - totalExp;
            decimal requiredMoney = totalExp - budget;
            

            if (budget >= totalExp )
            {
                Console.WriteLine($"Ivanovi will be left with {remainingMoney:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{requiredMoney:f2} leva needed.");
            }

        }
    }
}

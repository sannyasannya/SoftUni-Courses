using System;

namespace _05.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statistsCount = int.Parse(Console.ReadLine());
            double clothesPrise = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            clothesPrise = clothesPrise * statistsCount;

            if (statistsCount >= 150)
            {
                 double discount = clothesPrise * 0.1;
                clothesPrise = clothesPrise - discount;
            }

            double totalExpenses = clothesPrise + decor;

            if (totalExpenses > budget)
            {
                double requiredMoney = totalExpenses - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {requiredMoney:f2} leva more.");
            }
            else
            {
                double remainingMoney = budget - totalExpenses;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {remainingMoney:f2} leva left.");
            }
        }
    }
}

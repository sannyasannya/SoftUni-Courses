using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal neededMoney = decimal.Parse(Console.ReadLine());
            decimal availableMoney = decimal.Parse(Console.ReadLine());
            
            int dayCounter = 0;
            int spendingCounter = 0;

            while (availableMoney < neededMoney && spendingCounter < 5)
            {
                string actionType = Console.ReadLine();
                decimal money = decimal.Parse(Console.ReadLine());
                dayCounter++;

                if (actionType == "spend")
                {
                    availableMoney -= money;

                    if (money > availableMoney)
                    {
                        availableMoney = 0;
                    }

                    spendingCounter++;

                    if (spendingCounter == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine($"{dayCounter}");
                        return;
                    }
                }
                else if (actionType == "save")
                {
                    availableMoney += money;
                    spendingCounter = 0;
                }
            }       

             Console.WriteLine($"You saved the money for {dayCounter} days.");
            
        }
    }
}

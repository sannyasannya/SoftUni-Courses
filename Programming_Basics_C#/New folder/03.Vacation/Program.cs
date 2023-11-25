using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());           
            int daysCounter = 0;
            int totalDays = 0;

            while (daysCounter < 5 && ownedMoney < neededMoney)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                
                if (action == "save")
                {
                    ownedMoney += money;
                    daysCounter = 0;
                    
                }
                else 
                {
                    daysCounter++;
                    ownedMoney -= money;

                    if (money < 0)
                    {
                        money = 0;
                    }
                }
                totalDays++;                


                if (ownedMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {totalDays} days.");
                    break;
                }

                if (daysCounter == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine($"{totalDays}");
                    break;
                   
                }                
            }
          

        }
    }
}

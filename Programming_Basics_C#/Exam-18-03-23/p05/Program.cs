using System;

namespace p05
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double price = 0;

            while (command != "closed")
            {
                if (command == "haircut")
                {
                    string haircutType = Console.ReadLine();
                    if (haircutType == "mens")
                    {
                        price += 15;
                    }
                    else if (haircutType == "ladies")
                    {
                        price += 20;
                    }
                    else if (haircutType == "kids")
                    {
                        price += 10;
                    }
                }
                else if (command == "color")
                {
                    string colorType = Console.ReadLine();
                    if (colorType == "touch up")
                    {
                        price += 20;
                    }
                    else if (colorType == "full color")
                    {
                        price += 30;
                    }
                }

                if (price >= target)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (price >= target)
            {
                
                Console.WriteLine("You have reached your target for the day!");
                Console.WriteLine($"Earned money: {price}lv.");
            }
            else
            {
                double requiredMoney = target - price;
                Console.WriteLine($"Target not reached! You need {requiredMoney}lv. more.");
                Console.WriteLine($"Earned money: {price}lv.");
            }
        }
    }
}

using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();            

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double sum = 0;
                while (sum < budget)
                {
                    double currentSavedMoney = double.Parse(Console.ReadLine());
                    
                    sum += currentSavedMoney;
                }
                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }

        }
    }
}

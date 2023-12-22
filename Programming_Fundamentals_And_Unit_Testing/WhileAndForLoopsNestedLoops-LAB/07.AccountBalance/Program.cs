using System;

namespace _07.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalAmount = 0;

            while (command != "NoMoreMoney")
            {
                double deposit = double.Parse(command);
                if (deposit < 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }

                totalAmount += deposit;
                Console.WriteLine($"Increase: {deposit:f2}");
                command = Console.ReadLine();               

            }
            Console.WriteLine($"Total: {totalAmount:f2}");
        }
    }
}

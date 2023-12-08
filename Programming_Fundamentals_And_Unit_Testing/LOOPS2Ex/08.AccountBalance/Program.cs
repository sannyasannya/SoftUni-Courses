using System;

namespace _08.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double money = 0;
            

            while (command != "End")
            {
                double current = double.Parse(command);
                if (current > 0)
                {                    
                    Console.WriteLine($"Increase: {current:f2}");
                    money += current;
                    
                }
                else
                {                    
                    Console.WriteLine($"Decrease: {Math.Abs(current):f2}");
                    money += current;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Balance: {money:f2}");
        }
    }
}

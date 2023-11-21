using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int sum = 0;

            while (command != "Going home")
            {
                int steps = int.Parse(command);
                sum += steps;

                if (sum > 10000)
                {                   
                    Console.WriteLine($"Goal reached! Good job!");
                    Console.WriteLine($"{sum - 10000} steps over the goal!");
                    return;                    
                }                

                command = Console.ReadLine();                
            }
            int bonusSteps = int.Parse(Console.ReadLine());
            sum += bonusSteps;

            if (sum > 10000)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{sum - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - sum} more steps to reach goal.");
            }

        }
    }
}

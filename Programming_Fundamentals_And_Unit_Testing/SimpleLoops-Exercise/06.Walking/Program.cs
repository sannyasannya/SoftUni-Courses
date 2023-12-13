using System;

namespace _06.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int totalSteps = 10000;

            while (totalSteps >= 0)
            {
                if (command == "Going home")
                {
                    int bonusSteps = int.Parse(Console.ReadLine());
                    totalSteps -= bonusSteps;
                    break;
                }

                int currentSteps = int.Parse(command);
                totalSteps -= currentSteps;

                if (totalSteps <= 0)
                {
                    break;
                }
                command = Console.ReadLine();
            
            }

            if (totalSteps > 0)
            {
                Console.WriteLine($"{totalSteps} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{Math.Abs(totalSteps)} steps over the goal!");

            }


        }
    }
}

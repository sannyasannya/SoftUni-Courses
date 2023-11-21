using System;

namespace _07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widght = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int freeSpace = widght * lenght * height;           


            while (command != "Done")
            {                
                 int cartonsCount = int.Parse(command);
              

                if (freeSpace < cartonsCount)
                {
                   int requiredCubicMeter = cartonsCount - freeSpace;
                    Console.WriteLine($"No more free space! You need {requiredCubicMeter} Cubic meters more.");
                    return;                 
                }
                freeSpace -= cartonsCount;

                command = Console.ReadLine();
            }                   

              Console.WriteLine($"{freeSpace} Cubic meters left.");

            



        }
    }
}

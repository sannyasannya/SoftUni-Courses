using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = widht * lenght * height;
            string command = Console.ReadLine();
            double sum = 0;


            while (command != "Done")
            {
                int numberOfBoxes = int.Parse(command);
                sum += numberOfBoxes;

                if (sum > freeSpace)
                {
                    double requiredSpace = sum - freeSpace;
                    Console.WriteLine($"No more free space! You need {requiredSpace} Cubic meters more.");
                    return;
                }
                command = Console.ReadLine();
               
            }

            double remainingSpace = freeSpace - sum;
            Console.WriteLine($"{remainingSpace} Cubic meters left.");

               
        }
    }
}

using System;

namespace _08.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int wight = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int cakeSize = wight * lenght;
            string command = Console.ReadLine();
            double sum = 0;

            while (command != "STOP")
            {
                int cakePieces = int.Parse(command);
                sum += cakePieces;

                if (sum > cakeSize)
                {
                    Console.WriteLine($"No more cake left! You need {sum - cakeSize} pieces more.");
                    return;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{cakeSize - sum} pieces are left.");
        }
    }
}

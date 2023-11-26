using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int totalPieces = lenght * width;

            string input = Console.ReadLine();

            while (input != "STOP")
            {
                int currentPiece = int.Parse(input);

                if (currentPiece > totalPieces)
                {
                    double requiredPieces = currentPiece - totalPieces;
                    Console.WriteLine($"No more cake left! You need {requiredPieces} pieces more.");
                    return;
                    
                }
                else
                {
                    totalPieces -= currentPiece;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalPieces} pieces are left.");
        }
    }
}

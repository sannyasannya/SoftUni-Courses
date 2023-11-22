using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            int combinationCounter = 0;

            for (int x = num1; x <= num2; x++)
            {
                for (int y = num1; y <= num2; y++)
                {
                    combinationCounter++;

                    if (x + y == magicNumber)
                    {
                        counter++;
                        Console.WriteLine($"Combination N:{combinationCounter} ({x} + {y} = {magicNumber})");
                        return;
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
            }
        }
    }
}

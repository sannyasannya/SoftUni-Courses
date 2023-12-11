using System;

namespace _04.LetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char xLetter = char.Parse(Console.ReadLine());
            int count = 0;

            for (char i = startLetter; i <= endLetter; i++)
            {
                if (xLetter == i)
                {
                    continue;
                }

                for (char j = startLetter; j <= endLetter; j++)
                {
                    if (xLetter == j)
                    {
                        continue;
                    }

                    for (char k = startLetter; k <= endLetter; k++)
                    {
                        if (xLetter == k)
                        {
                            continue;
                        }
                        Console.Write($"{i}{j}{k} ");
                        count++;
                    }
                }
            }
            Console.WriteLine();
            Console.Write($"{count} ");

        }
    }
}

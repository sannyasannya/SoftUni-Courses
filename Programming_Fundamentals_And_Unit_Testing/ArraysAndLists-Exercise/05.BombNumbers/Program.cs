using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                               .Split(" ")
                               .Select(int.Parse)
                               .ToList();


            List<int> bomb = Console.ReadLine()
                               .Split(" ")
                               .Select(int.Parse)
                               .ToList();


            int bombNum = bomb[0];
            int powerNum = bomb[1];

            for (int i = 0; i < input.Count; i++)
            {

                if (input[i] == bombNum)
                {
                    int startIndex = i - powerNum;
                    int removeCount = powerNum + powerNum + 1;

                    if (startIndex < 0)
                    {
                        removeCount -= Math.Abs(startIndex);
                        startIndex = 0;
                    }

                    if (startIndex + removeCount > input.Count)
                    {
                        removeCount = input.Count - startIndex;
                    }

                    input.RemoveRange(startIndex, removeCount);
                    i = startIndex - 1;
                }
            }
            int sum = input.Sum();
            Console.WriteLine(sum);
        }
    }
}

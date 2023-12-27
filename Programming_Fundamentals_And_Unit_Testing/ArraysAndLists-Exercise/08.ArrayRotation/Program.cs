using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                    .Split(" ")
                                    .Select(int.Parse)
                                    .ToList();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currentNum = input[0];
                input.RemoveAt(0);
                input.Add(currentNum);
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}

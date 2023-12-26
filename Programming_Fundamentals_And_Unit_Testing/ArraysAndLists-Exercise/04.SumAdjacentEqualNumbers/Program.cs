using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input = Console.ReadLine()
                                    .Split(" ")
                                    .Select(int.Parse)
                                    .ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                int firstElement = input[i];
                int secondElement = input[i + 1];

                if (firstElement == secondElement)
                {
                    input[i] = firstElement + secondElement;
                    input.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}

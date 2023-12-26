using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToList();
            List<int> output = new List<int>();

            int lenght = input.Count / 2;
            int firstIndex = 0;
            int lastIndex = input.Count - 1;

            for (int i = 0; i < lenght; i++)
            {
                int firstElement = input[firstIndex];
                int lastElement = input[lastIndex];
                int sum = firstElement + lastElement;

                output.Add(sum);
                firstIndex++;
                lastIndex--;
            }

            if (input.Count % 2 == 1)
            {
                int middleElement = input[lenght];
                output.Add(middleElement);
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}

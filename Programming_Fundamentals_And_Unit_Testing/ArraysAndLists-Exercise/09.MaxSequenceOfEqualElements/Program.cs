using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.MaxSequenceOfEqualElements
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

            int counter = 1;
            int value = 0;
            int max = int.MinValue;

            for (int i = 0; i < input.Count - 1; i++)
            {
                int firstElement = input[i];
                int secondElement = input[i + 1];

                if (firstElement == secondElement)
                {
                    counter++;

                    if (counter > max)
                    {
                        max = counter;
                        value = input[i];
                    }

                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < max; i++)
            {
                output.Add(value);
            }
                Console.WriteLine(string.Join(" ", output));
           
        }
    }
}

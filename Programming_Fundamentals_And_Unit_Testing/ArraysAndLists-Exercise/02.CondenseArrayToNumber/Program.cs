using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CondenseArrayToNumber
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
            
            int sum = 0;

            if (input.Count == 1)
            {
                Console.WriteLine(input[0]);
                return;
            }

            while (input.Count > 1)
            {
                int lenght = input.Count - 1;

                for (int i = 0; i < lenght; i++)
                {
                    int firstElement = input[i];
                    int secondElement = input[i + 1];

                    int currentSum = firstElement + secondElement;
                    output.Add(currentSum);

                    if (input.Count == 2)
                    {
                        sum += firstElement + secondElement;
                    }
                }
                input.Clear();
                input.AddRange(output);
                output.Clear();
            }

            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.TopIntegers
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

            for (int i = 0; i < input.Count; i++)
            {
                int current = input[i];

                if (input.Count - 1 == i)
                {
                    output.Add(current);
                    break;
                }

                for (int j = i + 1; j < input.Count; j++)
                {
                    int nextNum = input[j];

                    if (current < nextNum)
                    {
                        break;
                    }
                    else if (current > nextNum && input.Count - 1 == j)
                    {
                        output.Add(current);
                    }
                    
                }
            }
            Console.WriteLine(string.Join(" ", output));

        }
    }
}

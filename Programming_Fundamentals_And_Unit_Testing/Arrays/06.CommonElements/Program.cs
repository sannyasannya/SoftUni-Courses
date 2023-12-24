using System;
using System.Linq;

namespace _06.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = Console.ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();

            int[] numbers2 = Console.ReadLine()
                           .Split(" ")
                           .Select(int.Parse)
                           .ToArray();

            var result = numbers1.Intersect(numbers2);

            foreach (var value in result)
            {
                Console.Write($"{value} ");
            }
        }
    }
}

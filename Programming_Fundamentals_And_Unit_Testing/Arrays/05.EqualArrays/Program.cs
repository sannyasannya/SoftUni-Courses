using System;
using System.Linq;

namespace _05.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                           .Split(" ")
                           .Select(int.Parse)
                           .ToArray();

            int[] array2 = Console.ReadLine()
                           .Split(" ")
                           .Select(int.Parse)
                           .ToArray();

            bool isIdentical = true;

            for (int i = 0; i <= array1.Length - 1; i++)
            {
                if (array1[i] != array2[i])
                {
                    isIdentical = false;
                    Console.WriteLine("Arrays are not identical.");
                    break;
                }
            }

            if (isIdentical)
            {
                Console.WriteLine("Arrays are identical.");
            }

        }
    }
}

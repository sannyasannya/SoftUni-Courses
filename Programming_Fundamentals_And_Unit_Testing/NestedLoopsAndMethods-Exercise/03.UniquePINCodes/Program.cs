using System;

namespace _03.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());

            for (int i = 2; i <= max1; i += 2)
            {
                for (int j = 1; j <= max2; j++)
                {
                    bool isPrime = j == 2 || j == 3|| j == 5 || j == 7;

                    if (isPrime == false)
                    {
                        continue;
                    }
                   
                    for (int k = 2; k <= max3; k += 2)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }
    }
}

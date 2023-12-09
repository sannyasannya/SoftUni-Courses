using System;

namespace _08.PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;
                int divider = 2;
                
                while (divider < end)
                {
                    if (i == divider)
                    {
                        divider++;
                        continue;
                    }

                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    divider++;
                }
                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }
            
        }
    }
}

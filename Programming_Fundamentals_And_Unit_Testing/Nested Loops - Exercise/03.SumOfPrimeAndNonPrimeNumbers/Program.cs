using System;

namespace _03.SumOfPrimeAndNonPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (command != "stop")
            {
                int number = int.Parse(command);

                if (number < 0)
                {
                    Console.WriteLine($"Number is negative.");                    
                }

                else
                {
                     int divisiorsCounter = 0;

                    for (int i = 1; i <= number; i++)
                    {
                        if (number % i == 0)
                        {
                            divisiorsCounter++;

                        }

                    }    
                    if (divisiorsCounter == 2)
                    {
                        primeSum += number;
                    }
                    else
                    {
                        nonPrimeSum += number;
                    }                    

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
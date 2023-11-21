using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());
            decimal cents = change * 100;
            int counter = 0;

            while (cents != 0)
            {
                if (cents >= 200)
                {
                    cents -= 200;
                }
                else if (cents >= 100)
                {
                    cents -= 100;
                }
                else if (cents >= 50)
                {
                    cents -= 50;
                }
                else if (cents >= 20)
                {
                    cents -= 20;
                }
                else if (cents >= 10)
                {
                    cents -= 10;
                }
                else if (cents >= 5)
                {
                    cents -= 5;
                }
                else if (cents >= 2)
                {
                    cents -= 2;
                }
                else if (cents >= 1)
                {
                    cents -= 1;
                }
                counter++;

            }
            Console.WriteLine(counter);
        }
    }
}

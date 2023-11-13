using System;

namespace _01.USDToBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double exchangeRate = 1.79549;
            double bgn = usd * exchangeRate;

            Console.WriteLine(bgn);
        }
    }
}

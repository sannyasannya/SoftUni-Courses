using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int periodInMonths = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());

            double interest = deposit * (interestRate/100);
            double interestForMonth = interest / 12;
            double result = deposit + periodInMonths * interestForMonth;

            Console.WriteLine(result);
          
            
        }
    }    
}

namespace _05.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            decimal annualInterestRate = decimal.Parse(Console.ReadLine());

            decimal accumulatedInterest = depositAmount * (annualInterestRate / 100);
            decimal interestForOneMonth = accumulatedInterest / 12;
            decimal totalAmount = depositAmount + (months * interestForOneMonth);

            Console.WriteLine($"{totalAmount:f2}");

        }
    }
}

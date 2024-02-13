namespace _03.Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tomatoPrice = double.Parse(Console.ReadLine());
            double tomatoQuantity = double.Parse(Console.ReadLine());
            double cucumberPrice = double.Parse(Console.ReadLine());
            double cucumberQuantity = double.Parse(Console.ReadLine());

            double totalTomatoPrice = tomatoPrice * tomatoQuantity;
            double totalCucumberPrice = cucumberPrice * cucumberQuantity;

            double totalPrice = totalTomatoPrice + totalCucumberPrice;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalCosts = 0;

            if (flowersType == "Roses")
            {
                totalCosts = 5 * flowersCount;

                if (flowersCount > 80)
                {
                    totalCosts = totalCosts - 0.1 * totalCosts;
                }
            }
            else if (flowersType == "Dahlias")
            {
                totalCosts = 3.8 * flowersCount;

                if (flowersCount > 90)
                {
                    totalCosts = totalCosts - 0.15 * totalCosts;
                }

            }
            else if (flowersType == "Tulips")
            {
                totalCosts = 2.8 * flowersCount;

                if (flowersCount > 80)
                {
                    totalCosts = totalCosts - 0.15 * totalCosts;
                }
            }
            else if (flowersType == "Narcissus")
            {
                totalCosts = 3 * flowersCount;

                if (flowersCount < 120)
                {
                    totalCosts = totalCosts + 0.15 * totalCosts;
                }
            }
            else if (flowersType == "Gladiolus")
            {
                totalCosts = 2.5 * flowersCount;

                if (flowersCount < 80)
                {
                    totalCosts = totalCosts + 0.2 * totalCosts;
                }
            }
            if (budget >= totalCosts)
            {
                double remainingMoney = budget - totalCosts;
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and {remainingMoney:f2} leva left.");
            }
            else
            {
                double requiredMoney = totalCosts - budget;
                Console.WriteLine($"Not enough money, you need {requiredMoney:f2} leva more.");
            }
        }
    }
}
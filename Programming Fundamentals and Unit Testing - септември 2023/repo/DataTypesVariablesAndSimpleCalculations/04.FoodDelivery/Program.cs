namespace _04.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double chickenMenuPrice = chickenMenu * 10.35;
            double fishMenuPrice = fishMenu * 12.40;
            double veganMenuPrice = veganMenu * 8.15;

            double sumMenu = chickenMenuPrice + fishMenuPrice + veganMenuPrice;

            double dessertPrice = sumMenu * 0.2;

            double totalOrder = sumMenu + dessertPrice + 2.5;

            Console.WriteLine(totalOrder);
        }
    }
}
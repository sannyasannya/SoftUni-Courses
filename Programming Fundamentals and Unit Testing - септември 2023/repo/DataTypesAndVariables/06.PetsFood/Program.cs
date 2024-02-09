namespace _06.PetsFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            double dogFoodPrice = dogFood * 2.5;
            double catFoodPrice = catFood * 4;
            double totalPrice = dogFoodPrice + catFoodPrice;

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
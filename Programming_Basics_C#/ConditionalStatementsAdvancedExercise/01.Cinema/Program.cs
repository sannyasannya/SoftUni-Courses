namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double ticketPrice = 0.0;

            if (type == "premiere")
            {
                ticketPrice = 12;
            }
            else if (type == "normal")
            {
                ticketPrice = 7.5;
            }
            else if (type == "discount")
            {
                ticketPrice = 5;
            }
            double totalIncome = rows * colums * ticketPrice;

            Console.WriteLine($"{totalIncome:f2} leva");
        }
    }
}
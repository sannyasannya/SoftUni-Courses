namespace _01.DayInMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int minutes = day * 24 * 60;

            Console.WriteLine($"Minutes = {minutes}");
        }
    }
}
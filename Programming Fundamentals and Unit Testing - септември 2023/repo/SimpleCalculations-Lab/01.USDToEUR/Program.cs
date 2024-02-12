namespace _01.USDToEUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double euro = usd * 0.88;

            Console.WriteLine($"{euro:f2}");
        }
    }
}
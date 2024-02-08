namespace _05.CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celcius = double.Parse(Console.ReadLine());
            double fahrenheit = (celcius * 1.8) + 32;

            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
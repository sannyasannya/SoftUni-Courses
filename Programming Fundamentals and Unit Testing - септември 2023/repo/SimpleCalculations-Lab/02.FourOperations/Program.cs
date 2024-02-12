namespace _02.FourOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double adding = num1 + num2;
            double substraction = num1 - num2;
            double multiplication = num1 * num2;
            double division = num1 / num2;

            Console.WriteLine($"{num1:f2} + {num2:f2} = {adding:f2}");
            Console.WriteLine($"{num1:f2} - {num2:f2} = {substraction:f2}");
            Console.WriteLine($"{num1:f2} * {num2:f2} = {multiplication:f2}");
            Console.WriteLine($"{num1:f2} / {num2:f2} = {division:f2}");
        }
    }
}
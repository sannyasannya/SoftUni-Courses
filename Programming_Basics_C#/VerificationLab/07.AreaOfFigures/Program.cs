using System;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double sideA = double.Parse(Console.ReadLine());
                double area = sideA * sideA;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * (Math.Pow(radius, 2));
                Console.WriteLine($"{area:F3}");

            }
            else if (figure == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double heightA= double.Parse(Console.ReadLine());
                double area = sideA * heightA /2;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}

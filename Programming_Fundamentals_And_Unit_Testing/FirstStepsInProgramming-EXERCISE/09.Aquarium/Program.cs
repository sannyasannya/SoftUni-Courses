using System;

namespace _09.Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int wight = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volume = lenght * wight * height;
            double volumeInLiters = volume * 0.001;
            double waterPercentage = (100 - percentage) / 100;
            double requiredLiters = volumeInLiters *  waterPercentage;

            Console.WriteLine($"{requiredLiters:f2}");
        }
    }
}

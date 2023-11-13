using System;

namespace _09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int widht = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volumeFishTank = lenght * widht * height;

            double volumeInLiters = volumeFishTank * 0.001;

        
            double liters = volumeInLiters - (percent * volumeInLiters / 100.0);

            Console.WriteLine(liters);       
             
        }
    }
}

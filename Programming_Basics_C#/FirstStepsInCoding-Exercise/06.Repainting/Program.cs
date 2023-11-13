using System;

namespace _06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int nylon = int.Parse(Console.ReadLine());
            int paintInLiters = int.Parse(Console.ReadLine());
            int diluentInLiters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

           
            double nylonCosts = (nylon + 2) * 1.5;
            double paintCosts = paintInLiters * 14.5 + 0.1 * (paintInLiters * 14.5);
            double diluentCosts = diluentInLiters * 5;

            double materialCosts = nylonCosts + paintCosts + diluentCosts + 0.4;

            double wagePerHour = materialCosts * 0.3;

            double totalHours = wagePerHour * hours;

            double endPrice = materialCosts + totalHours;

            Console.WriteLine(endPrice);
        }
    }
}

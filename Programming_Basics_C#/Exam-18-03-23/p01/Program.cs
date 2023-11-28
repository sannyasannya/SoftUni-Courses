using System;

namespace p01
{
    class Program
    {
        static void Main(string[] args)
        {
            int paperCount = int.Parse(Console.ReadLine());
            int clothCount = int.Parse(Console.ReadLine());
            double glueLiter = double.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());

            double paperPrice = paperCount * 5.8;
            double clothPrice = clothCount * 7.2;
            double gluePrice = glueLiter * 1.2;

            double materialsPrice = paperPrice + clothPrice + gluePrice;
            double priceDiscount = materialsPrice - (percentDiscount * materialsPrice / 100);

            Console.WriteLine($"{priceDiscount:f3}");
        }
    }
}

using System;

namespace _08.SortedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 < num2 && num1 < num3 && num2 < num3)
            {
                Console.WriteLine("Ascending");
            }
            else if (num1 > num2 && num1 > num3 && num2 > num3)
            {
                Console.WriteLine("Descending");
            }
            else
            {
                Console.WriteLine("Not sorted");
            }
        }
    }
}

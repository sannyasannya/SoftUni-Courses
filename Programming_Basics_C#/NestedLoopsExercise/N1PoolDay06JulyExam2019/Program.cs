using System;

namespace N1PoolDay06JulyExam2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entrance = double.Parse(Console.ReadLine());
            double sunLongerPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double sumPrice = people * entrance;
            double peopleForLonger = Math.Ceiling(0.75 * people);
            double totalLongerPrice = peopleForLonger * sunLongerPrice;
            double umbrellaForPeople = Math.Ceiling(0.5 * people);
            double totalUmbrellaPrice = umbrellaForPeople *umbrellaPrice;
            double totalPrice = sumPrice + totalLongerPrice + totalUmbrellaPrice;

            Console.WriteLine($"{totalPrice:f2} lv.");

        }
    }
}

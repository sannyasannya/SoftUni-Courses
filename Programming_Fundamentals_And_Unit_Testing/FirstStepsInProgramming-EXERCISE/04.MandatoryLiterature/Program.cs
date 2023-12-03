using System;

namespace _04.MandatoryLiterature
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int dayNumber = int.Parse(Console.ReadLine());

            int totalTime = numberOfPages / pagesPerHour;
            int hoursPerDay = totalTime / dayNumber;

            Console.WriteLine(hoursPerDay);
        }
    }
}

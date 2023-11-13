using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int readingTime = numberPages / pagesPerHour;
            int result = readingTime / days;

            Console.WriteLine(result);

           
        }
    }
}

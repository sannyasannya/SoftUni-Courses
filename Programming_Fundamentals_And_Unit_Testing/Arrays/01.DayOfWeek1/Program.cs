using System;

namespace _01.DayOfWeek1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            if (n >= 1 && n <= 7)
            {
                Console.WriteLine(daysOfWeek[n-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}

using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine().ToLower();

            bool isOpen = hour >= 10 && hour <= 18;

            if (isOpen)
            {
                bool isWorkingDay = day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday" || day == "saturday";

                if (isWorkingDay)
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
            else
            {
                Console.WriteLine("closed");
            }
        }

    }
}

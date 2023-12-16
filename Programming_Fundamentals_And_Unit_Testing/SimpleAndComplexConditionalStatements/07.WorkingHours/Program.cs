using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main()
        {
            int hour = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            bool isWorkingDay = dayOfWeek != "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday"
                || dayOfWeek == "Friday" || dayOfWeek == "Saturday";

            if (isWorkingDay)
            {
                if (hour >= 10 && hour <= 18)
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                Console.WriteLine("closed");
            }
        }
    }

}

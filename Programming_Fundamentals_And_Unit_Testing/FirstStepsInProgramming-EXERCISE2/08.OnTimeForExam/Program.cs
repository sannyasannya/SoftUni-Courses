using System;

namespace _08.OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinute = int.Parse(Console.ReadLine());

            int examTimeInMinute = (examHour * 60) + examMinute;
            int arriveTimeInMinute = (arriveHour * 60) + arriveMinute;

            if (examTimeInMinute >= arriveTimeInMinute)
            {
                int diff = examTimeInMinute - arriveTimeInMinute;
                if (diff <= 30)
                {
                    Console.WriteLine("On time");

                    if (diff > 0)
                    {

                        Console.WriteLine($"{diff} minutes before the start");
                    }
                                       

                }
                else if (diff > 30)
                {
                    Console.WriteLine("Early");                  
                   
                    int hours = diff / 60;
                    int minutes = diff - (hours * 60);

                    if (hours > 0)
                    {
                        if (minutes < 10)
                        {

                            Console.WriteLine($"{hours}:0{minutes} hours before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{hours}:{minutes} hours before the start");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{diff} minutes before the start");
                    }

                   
                }

            }
            else if (examTimeInMinute < arriveTimeInMinute)
            {
                Console.WriteLine("Late");

                int diff = arriveTimeInMinute - examTimeInMinute;
                int hours = diff / 60;
                int minutes = diff - (hours * 60);

                if (hours > 0)
                {
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hours}:{minutes} hours after the start");

                    }
                }
                else
                {
                    Console.WriteLine($"{diff} minutes after the start");
                }                

            }
        }
    }
}

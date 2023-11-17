namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minuteArrive = int.Parse(Console.ReadLine());

            int examTime = hourExam * 60 + minuteExam;
            int arriveTime = hourArrive * 60 + minuteArrive;

            if (arriveTime > examTime)
            {
                Console.WriteLine("Late");

                int minutesAfterStart = arriveTime - examTime;

                if (minutesAfterStart >= 60)
                {
                    int hours = minutesAfterStart / 60;
                    int minutes = minutesAfterStart - (hours * 60);

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
                    Console.WriteLine($"{minutesAfterStart} minutes after the start");
                }
            }
            else if (arriveTime == examTime)
            {
                Console.WriteLine("On time");
            }

            else if (arriveTime < examTime)
            {
                int minutesBeforeStart = examTime - arriveTime;

                if (minutesBeforeStart <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{minutesBeforeStart} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");

                    if (minutesBeforeStart >= 60)
                    {
                        int hours = minutesBeforeStart / 60;
                        int minutes = minutesBeforeStart - (hours * 60);

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
                        if (minutesBeforeStart < 10)
                        {
                            Console.WriteLine($"0{minutesBeforeStart} minutes before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{minutesBeforeStart} minutes before the start");
                        }
                    }

                }
            }
        }
    }
}
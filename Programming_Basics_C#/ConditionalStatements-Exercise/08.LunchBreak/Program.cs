using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int durationMovie = int.Parse(Console.ReadLine());
            int durationBreak = int.Parse(Console.ReadLine());

            double lunchTime = durationBreak * (1 / 8.0);
            double breakTime = durationBreak * (1 / 4.0);
            double timeLeft = durationBreak - lunchTime - breakTime;

            if (timeLeft >= durationMovie)
            {
                double remainingTime = timeLeft - durationMovie;
                Console.WriteLine($"You have enough time to watch {movieName} and left with {Math.Ceiling (remainingTime)} minutes free time.");
            }
            else
            {
                double requiredTime = durationMovie - timeLeft;
                Console.WriteLine($"You don't have enough time to watch {movieName}, you need {Math.Ceiling(requiredTime)} more minutes.");
            }
        }
    }
}

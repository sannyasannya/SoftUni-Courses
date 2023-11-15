using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Input
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeToSwimInSeconds = double.Parse(Console.ReadLine());

            //2.Calculate
            double timeToSwimDistanceInSeconds = distanceInMeters * timeToSwimInSeconds;

            //3.resistance
            double resistance = Math.Floor(distanceInMeters /15) * 12.5;
            double totalTime = timeToSwimDistanceInSeconds + resistance;

            //4.output
            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                double requiredSeconds = totalTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {requiredSeconds:f2} seconds slower.");
            }

        }
    }
}

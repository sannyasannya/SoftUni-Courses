using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main()
        {
            int juryCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double gradeCounter = 0;
            double totalSum = 0;

            while (presentationName != "Finish")
            {
                double avgSum = 0;
                for (int i = 1; i <= juryCount; i++)
                {
                    double assestment = double.Parse(Console.ReadLine());
                    avgSum += assestment;
                }

                double avgGrade = avgSum / juryCount;
                
                Console.WriteLine($"{presentationName} - {avgGrade:f2}.");
                totalSum += avgGrade;
                gradeCounter++;
                presentationName = Console.ReadLine();
            }

            double averageSuccess = totalSum / gradeCounter;
            Console.WriteLine($"Student's final assessment is {averageSuccess:f2}.");
        }
    }
}

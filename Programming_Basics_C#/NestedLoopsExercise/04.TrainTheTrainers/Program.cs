using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgeCount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();          
           
            double totalSum = 0;
            double gradeCounter = 0;

            while (input != "Finish")
            {                
                double presentationSum = 0;

                for (int i = 1; i <= judgeCount; i++)
                {                   
                    double presentationGrade = double.Parse(Console.ReadLine());
                    presentationSum += presentationGrade;
                    totalSum += presentationGrade;
                    gradeCounter++;        
                }
                presentationSum = presentationSum / judgeCount;               

                Console.WriteLine($"{input} - {presentationSum:f2}.");               

                input = Console.ReadLine();
            }
            double averageSuccess = totalSum / gradeCounter;
            Console.WriteLine($"Student's final assessment is {averageSuccess:f2}.");
        }
    }
}

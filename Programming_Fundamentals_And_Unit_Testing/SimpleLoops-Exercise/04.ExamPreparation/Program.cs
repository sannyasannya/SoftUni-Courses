using System;

namespace _04.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPoorGrades = int.Parse(Console.ReadLine());           
            
            int poorGradeCounter = 0;
            double sumGrade = 0;
            string lastProblem = string.Empty;
            int problemCounter = 0;

            while (poorGradeCounter < numberPoorGrades)
            {
               string problemName = Console.ReadLine();

                if ("Enough" == problemName)
                {                   
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    poorGradeCounter++;

                    if (poorGradeCounter == numberPoorGrades)
                    {
                        Console.WriteLine($"You need a break, {poorGradeCounter} poor grades.");
                        return;
                    }
                    
                }

                sumGrade += grade;               
                lastProblem = problemName;
                problemCounter++;
            }

            Console.WriteLine($"Average score: {(sumGrade / problemCounter):f2}");
            Console.WriteLine($"Number of problems: {problemCounter}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}

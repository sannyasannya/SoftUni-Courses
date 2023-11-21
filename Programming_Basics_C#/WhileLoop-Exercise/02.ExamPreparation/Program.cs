using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGrade = int.Parse(Console.ReadLine());

            int sumGrade = 0;
            int poorGradeCounter = 0;
            double counter = 0;

            string lastProblemsName = "";
            string problemsName = Console.ReadLine();

            while (problemsName != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());                              

                if (grade <= 4)
                {
                    poorGradeCounter++;

                    if (poorGrade == poorGradeCounter)
                    {
                        Console.WriteLine($"You need a break, {poorGrade} poor grades.");
                        return;
                    }
                }
                counter++;
                sumGrade += grade;

                lastProblemsName = problemsName;
                problemsName = Console.ReadLine();
            }
            double averageScore = (double)sumGrade / counter;
            Console.WriteLine($"Average score: {averageScore:f2}");

            Console.WriteLine($"Number of problems: {counter}");

            Console.WriteLine($"Last problem: {lastProblemsName}");

        }
    }
}

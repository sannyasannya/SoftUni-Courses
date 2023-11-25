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

            string lastProblemsName = "";
            string problemsName = Console.ReadLine();

            while (problemsName != "Enough")
            {                
                int grade = int.Parse(problemsName);                

                if (grade <= 4)
                {
                    poorGradeCounter++;
                }
                sumGrade += grade;

                lastProblemsName = problemsName;
                problemsName = Console.ReadLine();

            }
        }
    }
}

using System;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();            

            int currentClass = 1;
            int poorGradeCount = 0;
            double sum = 0;

            while (currentClass <= 12)
            {
                double yearGrade = double.Parse(Console.ReadLine());

                if (yearGrade < 4)
                {
                    poorGradeCount++;

                    if (poorGradeCount > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {currentClass} grade");
                        return;
                    }

                    continue;
                }
                sum += yearGrade;
                currentClass++;
            }

            double averageGrade = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
           
        }
    }
}

using System;

namespace _10.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();            
            int classNumber = 1;
            int poorGradeCounter = 0;
            double sum = 0;

            while (classNumber <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    poorGradeCounter++;

                    if (poorGradeCounter > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {classNumber} grade");
                        return;
                    }


                    continue;
                }

                sum += grade;
                classNumber++;
            }

            double averageGrade = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {(averageGrade):f2}");
        }
    }
}

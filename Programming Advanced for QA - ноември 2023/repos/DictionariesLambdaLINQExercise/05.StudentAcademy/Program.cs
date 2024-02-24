using System.Xml.Linq;

namespace _05.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
            }

            foreach (KeyValuePair<string, List<double>> pair in students) 
            {
                double averageGrade = pair.Value.Average();

                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{pair.Key} -> {averageGrade:f2}");
                }
                
            }
        }
    }
}
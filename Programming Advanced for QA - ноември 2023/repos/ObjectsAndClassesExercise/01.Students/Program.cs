namespace _01.Students
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Students> student = new List<Students>();

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split(" ");
                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                Students students = new Students(firstName, lastName, grade); 
                student.Add(students);
            }
            student = student.OrderByDescending(x => x.Grade).ToList();

            foreach(Students personStudent in student) 
            {
                Console.WriteLine($"{personStudent.FirstName} {personStudent.LastName}: {personStudent.Grade:f2}");
            }
        }

    }
}
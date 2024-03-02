namespace _02.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string command = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] input = command.Split(" ");
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];

                Student student = new Student();
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = homeTown;

                students.Add(student);

                command = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
}
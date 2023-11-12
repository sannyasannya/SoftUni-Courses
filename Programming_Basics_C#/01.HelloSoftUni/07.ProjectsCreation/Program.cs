using System;

namespace _07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int countOfProject = int.Parse(Console.ReadLine());
            int result = countOfProject * 3;

            Console.WriteLine($"The architect {name} will need {result} hours to complete {countOfProject} project/s.");
        }
    }
}

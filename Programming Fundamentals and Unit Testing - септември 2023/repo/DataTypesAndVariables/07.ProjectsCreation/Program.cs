namespace _07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int countOfProjects = int.Parse(Console.ReadLine());
            int neededHours = countOfProjects * 3;

            Console.WriteLine($"The architect {name} will need {neededHours} hours to complete {countOfProjects} project/s.");
        }
    }
}
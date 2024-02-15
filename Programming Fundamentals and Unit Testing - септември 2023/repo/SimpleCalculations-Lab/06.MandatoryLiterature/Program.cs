namespace _06.MandatoryLiterature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesForHour = int.Parse(Console.ReadLine());
            int numberOfDay = int.Parse(Console.ReadLine());

            int readingTime = pages / pagesForHour;
            int requiredHours = readingTime / numberOfDay;

            Console.WriteLine(requiredHours);
        }
    }
}
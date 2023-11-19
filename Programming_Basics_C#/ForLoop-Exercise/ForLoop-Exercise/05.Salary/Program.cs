namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabsNumber = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int fine = 0;

            for (int i = 0; i < tabsNumber && fine < salary; i++)
            {
                string site = Console.ReadLine();

                if (site == "Facebook")
                {
                    fine += 150;
                }
                else if (site == "Instagram")
                {
                    fine += 100;
                }
                else if (site == "Reddit")
                {
                    fine += 50;
                }
            }


            int salaryWithFine = salary - fine;

            if (fine >= salary)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salaryWithFine);
            }
        }
    }
}
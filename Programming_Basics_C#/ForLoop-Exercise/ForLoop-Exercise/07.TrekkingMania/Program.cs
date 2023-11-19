namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            int totalNumber = 0;

            for (int i = 0; i < n; i++)
            {
                int peopleInGroups = int.Parse(Console.ReadLine());

                if (peopleInGroups <= 5)
                {
                    p1 += peopleInGroups;
                }
                else if (peopleInGroups <= 12)
                {
                    p2 += peopleInGroups;
                }
                else if (peopleInGroups <= 25)
                {
                    p3 += peopleInGroups;
                }
                else if (peopleInGroups <= 40)
                {
                    p4 += peopleInGroups;
                }
                else
                {
                    p5 += peopleInGroups;
                }

                totalNumber += peopleInGroups;
            }

            Console.WriteLine($"{(double)p1 / totalNumber * 100:f2}%");
            Console.WriteLine($"{(double)p2 / totalNumber * 100:f2}%");
            Console.WriteLine($"{(double)p3 / totalNumber * 100:f2}%");
            Console.WriteLine($"{(double)p4 / totalNumber * 100:f2}%");
            Console.WriteLine($"{(double)p5 / totalNumber * 100:f2}%");

        }
    }
}
namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentCounts = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int newPoints = 0;
            int countOfWonTourmanets = 0;

            for (int i = 0; i < tournamentCounts; i++)
            {
                string stage = Console.ReadLine();

                if (stage == "W")
                {
                    newPoints += 2000;
                    countOfWonTourmanets++;
                }
                else if (stage == "F")
                {
                    newPoints += 1200;

                }
                else if (stage == "SF")
                {
                    newPoints += 720;
                }
            }

            int finalPoints = startingPoints + newPoints;
            double averagePoints = (newPoints / tournamentCounts);
            double winRatio = (double)countOfWonTourmanets / tournamentCounts * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{winRatio:f2}%");
        }
    }
}
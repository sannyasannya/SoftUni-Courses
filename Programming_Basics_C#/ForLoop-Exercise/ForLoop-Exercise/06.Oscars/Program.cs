namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string actorName = Console.ReadLine();
            double startingPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            double scorePoints = startingPoints;

            for (int i = 0; i < n; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());
                int judgeNameLenght = judgeName.Length;

                scorePoints = scorePoints + ((judgeNameLenght * judgePoints) / 2);

                if (scorePoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {scorePoints:f1}!");
                    return;
                }
            }

            double requiredPoints = 1250.5 - scorePoints;
            Console.WriteLine($"Sorry, {actorName} you need {requiredPoints:f1} more!");
        }
    }
}
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})(?<sep>[\.\-\/])(?<month>[A-Za-z]{3})\2(?<year>\d{4})\b";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups[1]}, Month: {match.Groups[3]}, Year: {match.Groups[4]}");
            }

        }
    }
}
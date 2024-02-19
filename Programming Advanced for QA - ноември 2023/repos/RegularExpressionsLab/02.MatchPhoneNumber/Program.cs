using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([\ \-])2\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
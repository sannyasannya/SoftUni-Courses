namespace CVSParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "hello";
            string[] result = CsvParser.ParseCsv(input);
            Console.WriteLine(result);
        }
    }

    public class CsvParser
    {
        public static string[] ParseCsv(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
            {
                return Array.Empty<string>();
            }

            return csvData.Trim().Split(',', StringSplitOptions.TrimEntries);
        }
    }
}
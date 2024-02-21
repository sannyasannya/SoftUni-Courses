namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");

            Dictionary<string, int> wordsCount = new();

            foreach (var word in words)
            {
                string caseInsensitive = word.ToLower();

                if (wordsCount.ContainsKey(caseInsensitive))
                {
                    wordsCount[caseInsensitive] += 1;
                }
                else
                {
                    wordsCount.Add(caseInsensitive, 1);
                }
            }

            foreach (KeyValuePair<string, int> pair in wordsCount)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.Write($"{pair.Key} ");
                }
            }

        }
    }
}
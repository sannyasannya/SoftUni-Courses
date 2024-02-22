namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonyms = new();

            for (int i = 0; i < numberCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonym);
                }
                else
                {
                    synonyms.Add(word, new List<string> { synonym });
                }
            }

            foreach (KeyValuePair<string, List<string>> pair in synonyms) 
            {
                Console.WriteLine($"{pair.Key} - {string.Join(", ", pair.Value)}");
            }

        }
    }
}
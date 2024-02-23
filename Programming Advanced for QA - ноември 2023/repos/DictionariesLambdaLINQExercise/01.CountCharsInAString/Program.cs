namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> chars = new();
            
            string input = Console.ReadLine();

            foreach (char ch in input)
            {
                if (ch == ' ') 
                {
                    continue;
                }

                if (chars.ContainsKey(ch))
                {
                    chars[ch]++;
                }
                else
                {
                    chars.Add(ch, 1);
                }
            }

            foreach (KeyValuePair<char, int> pair in chars) 
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
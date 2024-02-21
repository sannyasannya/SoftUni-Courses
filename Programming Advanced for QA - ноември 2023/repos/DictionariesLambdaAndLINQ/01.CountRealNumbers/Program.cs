namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SortedDictionary<int, int> num = new();

            foreach (int number in numbers)
            {
                if (num.ContainsKey(number))
                {
                    num[number] += 1;
                }
                else
                {
                    num.Add(number, 1);
                    //num[numbers] = 1;
                }
            }

            foreach (KeyValuePair<int, int> pair in num) 
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }          

        }
    }
}
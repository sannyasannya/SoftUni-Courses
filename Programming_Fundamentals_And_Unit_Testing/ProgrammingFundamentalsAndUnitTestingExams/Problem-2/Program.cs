namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                              .Split(" ")
                              .Select(int.Parse)
                              .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int lastNum = input[input.Count - 1];
                input.RemoveAt(input.Count - 1);
                input.Insert(0, lastNum);

            }
            Console.WriteLine(string.Join(", ", input).Trim());
        }
    }
}
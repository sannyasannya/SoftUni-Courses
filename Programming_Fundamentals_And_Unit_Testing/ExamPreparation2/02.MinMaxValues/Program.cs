namespace _02.MinMaxValues
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

            int maxNum = int.MinValue;
            int minNum = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int currentNum = input[i];

                if (currentNum > maxNum)
                {
                    maxNum = currentNum;
                }

                if (currentNum < minNum)
                {
                    minNum = currentNum;
                }
            }
            Console.WriteLine($"{maxNum}");
            Console.WriteLine($"{minNum}");
        }
    }
}
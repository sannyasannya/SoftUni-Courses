namespace _2.MinMax2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                                 .Split(" ")
                                 .Select(int.Parse)
                                 .ToList();

            int n = int.Parse(Console.ReadLine());

            List<int> secondList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currentNum = firstList[i];
                secondList.Add(currentNum);
            }
            Console.WriteLine(secondList.Max());
            Console.WriteLine(secondList.Min());

        }
    }
}
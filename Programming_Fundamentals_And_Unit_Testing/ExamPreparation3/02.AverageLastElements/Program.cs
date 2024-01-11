namespace _02.AverageLastElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                             .Split(" ")
                             .Select(int.Parse)
                             .ToList();

            int num = int.Parse(Console.ReadLine());

            double sum = 0;

            List<int> output = new List<int>();

            for (int i = list.Count - 1; i > list.Count - 1 - num; i--)
            {
                int currentNum = list[i];
                sum += currentNum;
            }

            double average = sum / num;

            Console.WriteLine($"{average:f2}");
        }
    }
}
namespace _02.MiddleElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                              .Split(" ")
                              .Select(int.Parse)
                              .ToArray();

            int middleRightIndex = numbers.Length / 2;
            int middleLeftIndex = middleRightIndex - 1;

            int middleRightElement = numbers[middleRightIndex];
            int middleLeftElement = numbers[middleLeftIndex];

            double middleElementAverage = (middleRightElement + middleLeftElement) / 2.0;

            Console.WriteLine($"{middleElementAverage:f2}");



        }
    }
}
namespace _02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int maxNum = int.MinValue;


            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                sum = currentNumber + sum;

                if (currentNumber > maxNum)
                {
                    maxNum = currentNumber;
                }
            }

            int sumWithoutMaxNumber = sum - maxNum;

            if (sumWithoutMaxNumber == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutMaxNumber} ");
            }
            else
            {
                int diff = Math.Abs(sumWithoutMaxNumber - maxNum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
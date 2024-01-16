namespace _1.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string numAsString = input[i].ToString();
                int num = int.Parse(numAsString);

                if (num % 2 == 0)
                {
                    int resultFactorial = CalculateFactorial(num);
                    totalSum += resultFactorial;
                }
            }
            Console.WriteLine(totalSum);
        }

        static int CalculateFactorial(int number)
        {
            int result = 1;

            while (number > 0)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
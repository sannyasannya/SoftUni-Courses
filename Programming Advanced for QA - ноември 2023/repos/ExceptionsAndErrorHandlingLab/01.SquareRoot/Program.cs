namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            try
            {
                if (num < 0)
                {
                    throw new ArgumentException();
                }
                double sqrt = Math.Sqrt(num);
                Console.WriteLine(sqrt);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally 
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
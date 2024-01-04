namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] result = new[] { "{", "{" };
            Console.WriteLine(BalancedBrackets.IsBalanced(result));
        }

    }
    public class BalancedBrackets
    {
        public static bool IsBalanced(string[] input)
        {
            int balance = 0;

            foreach (string symbol in input)
            {
                if (symbol == "(")
                {
                    balance++;
                }
                else if (symbol == ")")
                {
                    balance--;
                }

                if (balance < 0)
                {
                    return false;
                }
            }

            return balance == 0;
        }
    }

}
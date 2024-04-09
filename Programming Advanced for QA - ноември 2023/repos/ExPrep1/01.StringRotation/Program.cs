namespace _01.StringRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "notebook";
            int position = 15;

            string result = StringRotator.RotateRight(input, position);
            Console.WriteLine(result);
        }
    }
    public class StringRotator
    {
        public static string RotateRight(string input, int positions)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            int length = input.Length;
            positions = Math.Abs(positions);
            positions %= length;

            return input.Substring(length - positions) + input.Substring(0, length - positions);
        }
    }

}
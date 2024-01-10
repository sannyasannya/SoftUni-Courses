namespace _01.EnglishNameOfEachDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int current = int.Parse(input[i].ToString());

                string output = NumberAsLetter(current);

                Console.WriteLine(output);
            }  

        }

        static string NumberAsLetter(int number)
        {
            string result = string.Empty;

            if (number == 1)
            {
                result = "one";
            }
            else if (number == 2)
            {
                result = "two";
            }
            else if (number == 3)
            {
                result = "three";
            }
            else if (number == 4)
            {
                result = "four";
            }
            else if (number == 5)
            {
                result = "five";
            }
            else if (number == 6)
            {
                result = "six";
            }
            else if (number == 7)
            {
                result = "seven";
            }
            else if (number == 8)
            {
                result = "eight";
            }
            else if (number == 9)
            {
                result = "nine";
            }

            return result;
        }
    }

}
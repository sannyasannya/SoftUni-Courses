using System.Text;

namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder chars = new StringBuilder();

            foreach (var symbol in text)
            {
                if (char.IsDigit(symbol) )
                {
                    digits.Append(symbol);
                }
                else if (char.IsLetter(symbol) )
                {
                    letters.Append(symbol);
                }
                else
                {
                    chars.Append(symbol);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(chars);
        }
    }
}
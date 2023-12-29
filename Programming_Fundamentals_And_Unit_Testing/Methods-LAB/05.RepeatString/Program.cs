using System;

namespace _05.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(text, count);
            Console.WriteLine(result);
        }

        static string RepeatString(string text, int count)
        {
            string output = string.Empty;
            for (int i = 0; i < count; i++)
            {
                output += text;
            }
            return output;
        }       
    }
}

using System;

namespace _06.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int vowelCount = 0;
            

            for (int i = 0; i < text.Length; i++)
            {
                vowelCount = GetVowelCount(text, vowelCount, i);
            }
            Console.WriteLine(vowelCount);


        }

        private static int GetVowelCount(string text, int vowelCount, int i)
        {
            char current = text[i];
            bool isVowel = current == 'a' || current == 'A' || current == 'o' || current == 'O'
                || current == 'e' || current == 'E' || current == 'i' || current == 'I' || current == 'u' || current == 'U';

            if (isVowel)
            {
                vowelCount++;
            }

            return vowelCount;
        }
    }
}

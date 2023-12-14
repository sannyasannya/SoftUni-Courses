using System;

namespace _07.VowelOrConsonant
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            switch (letter)
            {
                case 'a':                    
                case 'A':
                case 'e':
                case 'E':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U': Console.WriteLine("Vowel");
                    break;

                default: Console.WriteLine("Consonant");
                    break;
            }
        }
    }
}

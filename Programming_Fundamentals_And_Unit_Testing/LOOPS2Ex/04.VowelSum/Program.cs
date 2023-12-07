using System;

namespace _04.VowelSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            

            int value = 0;

            for (int i = 1; i <= count; i++)
            {
                char vowel = char.Parse(Console.ReadLine());

                if (vowel == 'a')
                {
                    value += 1;
                }
                else if (vowel == 'e')
                {
                    value += 2;
                }
                else if (vowel == 'i')
                {
                    value += 3;
                }
                else if (vowel == 'o')
                {
                    value += 4;
                }
                else if (vowel == 'u')
                {
                    value += 5;
                }
            }
            Console.WriteLine(value);
        }
    }
}

using System;

namespace _06.SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int startNum = number;
            bool isSpecial = true;

            while (number > 0)
            {
                int lastDigit = number % 10;

                if (startNum % lastDigit != 0)
                {
                    isSpecial = false;
                    break;
                    
                }
                
                number = number / 10;

            }

            if (isSpecial)
            {
                Console.WriteLine($"{startNum} is special");
            }
            else
            {
                Console.WriteLine($"{startNum} is not special");
            }
            
        }
    }
}

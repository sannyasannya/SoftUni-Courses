using System;

namespace _01.StupidPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int firstNum = 2; firstNum <= number; firstNum += 2)
            {
                for (int secondNum = 1; secondNum <= number;  secondNum +=2)
                {
                    Console.Write($"{firstNum}{secondNum}{firstNum * secondNum} ");
                }
            }
        }
    }
}

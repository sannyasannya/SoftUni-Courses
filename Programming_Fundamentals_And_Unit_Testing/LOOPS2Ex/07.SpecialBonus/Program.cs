using System;

namespace _07.SpecialBonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double stopNum = double.Parse(Console.ReadLine());
            double prevNumber = 0; 

            while (prevNumber != stopNum)
            {
                 double number = double.Parse(Console.ReadLine());

                if (number != stopNum)
                {
                    prevNumber = number;
                }
                else
                {
                    prevNumber *= 1.2;
                    break;
                }
            }
            Console.WriteLine(prevNumber);
        }
    }
}

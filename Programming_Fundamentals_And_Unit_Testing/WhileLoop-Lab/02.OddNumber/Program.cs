using System;

namespace _02.OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number % 2 == 0)
            {    
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(number);
        }
    }
}

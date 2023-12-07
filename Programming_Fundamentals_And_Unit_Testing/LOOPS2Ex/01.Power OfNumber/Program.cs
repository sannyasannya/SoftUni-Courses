using System;

namespace _01.Power_OfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int powerNum = int.Parse(Console.ReadLine());

            int result = 1;

            for (int i = 1; i <= powerNum; i++)
            {
                result = result * number;
            }
            Console.WriteLine(result);
        }
    }
}

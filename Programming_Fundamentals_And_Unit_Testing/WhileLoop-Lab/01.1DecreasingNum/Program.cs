using System;

namespace _01._1DecreasingNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            while (num >= 1)
            {
                Console.WriteLine(num);
                num--;
            }
        }
    }
}

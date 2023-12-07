using System;

namespace _02.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int result = 1;

            for (int i = 1; i <= 10; i++)
            {
                result = num * i;

                Console.WriteLine($"{num} x {i} = {result}");
            }
            
        }
    }
}

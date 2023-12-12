using System;

namespace _05.NumberInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            while ( num > 0 || num <= 100)
            {
                if (num > 100 || num <= 0)
                {
                    num = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(num);
            
        }
    }
}

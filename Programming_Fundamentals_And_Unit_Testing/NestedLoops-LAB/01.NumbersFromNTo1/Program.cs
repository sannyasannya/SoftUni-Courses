using System;

namespace _01.NumbersFromNTo1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n >= 1)
            {
                Console.WriteLine(n);
                n--;
            }
        }
    }
}

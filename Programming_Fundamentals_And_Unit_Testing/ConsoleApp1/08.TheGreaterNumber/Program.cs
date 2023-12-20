using System;

namespace _08.TheGreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("Greater number: " + a);
            }
            else if (a < b)
            {
                Console.WriteLine("Greater number: " + b);
            }
            else
            {
                Console.WriteLine("The two numbers are equal.");
            }
        }
    }
}

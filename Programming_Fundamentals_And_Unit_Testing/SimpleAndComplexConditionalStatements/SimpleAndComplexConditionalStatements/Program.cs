using System;

namespace SimpleAndComplexConditionalStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("negative");
            }
            else if (num > 0)
            {
                Console.WriteLine("positive");
            }
            else if (num == 0)
            {
                Console.WriteLine("zero");
            }       
        }
    }
}

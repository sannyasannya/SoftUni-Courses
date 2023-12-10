using System;

namespace Nested_Loops___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;


            for (int rows = 1; rows <= n; rows++)
            {
                for (int col = 1; col <= rows; col++)
                {
                    if (current > n)
                    {
                        break;
                    }
                    Console.Write($"{current} ");
                    current++;

                    if (col == rows)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

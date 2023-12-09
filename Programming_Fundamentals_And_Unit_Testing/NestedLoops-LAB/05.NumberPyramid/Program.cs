using System;

namespace _05.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int row = 1; row <= num; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (sum < num)
                    {
                        sum++;
                        
                        Console.Write($" {sum}");
                    }                   
                }
                Console.WriteLine();
            }
        }
    }
}

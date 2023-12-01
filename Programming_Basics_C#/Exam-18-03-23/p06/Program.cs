using System;

namespace p06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 9; j > i; j--)
                {
                    for (int k = 0; k <= 9; k++)
                    {
                        for (int m = 9; m > k; m--)
                        {
                            if ((i + j + k + m) == (i * j * k * m) && (n % 10 == 5 || n == 5))
                            {
                                Console.WriteLine($"{i}{j}{k}{m}");
                                return;
                            }

                            if ((i * j * k * m) / (i + j + k + m) == 3 && n % 3 == 0)
                            {
                                Console.WriteLine($"{m}{k}{j}{i}");
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Nothing found");
        }
    }
}

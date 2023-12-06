using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNum = int.Parse(Console.ReadLine());           
            double sum = 0;  

            for (int i = 0; i < countNum; i++)
            {
                double number = double.Parse(Console.ReadLine());
                sum += number;

            }
            Console.WriteLine(sum);
        }
    }
}

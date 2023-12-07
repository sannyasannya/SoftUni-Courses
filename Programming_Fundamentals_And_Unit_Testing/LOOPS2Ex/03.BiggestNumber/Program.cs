using System;

namespace _03.BiggestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNum = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;


            for (int i = 1; i <= countNum; i++)
            {
                int value = int.Parse(Console.ReadLine());

                if (value > maxNum)
                {
                    maxNum = value;
                }
            }
            Console.WriteLine(maxNum);

        }
    }
}

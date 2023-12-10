using System;

namespace _02.EqualSumOfEvenAndOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= lastNum; i++)
            {
                string currentNum = i.ToString();
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {                    
                    int number = int.Parse(currentNum[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenSum += number;
                    }
                    else
                    {
                        oddSum += number;
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.Write($"{i} " );
                }
            }  
        }
    }
}

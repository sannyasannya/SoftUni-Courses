using System;

namespace _09.TheSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (command != "Stop")
            {
                int num = int.Parse(command);

                if (num < minNumber)
                {
                    minNumber = num;
                }
                    
                command = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}

using System;

namespace _06.NumberProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Inc")
                {
                    number++;
                }
                else if (command == "Dec")
                {
                    number--;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(number);
        }
    }
}

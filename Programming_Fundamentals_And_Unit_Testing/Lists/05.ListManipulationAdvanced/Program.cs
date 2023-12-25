using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParts = command.Split(" ");
                string commandName = commandParts[0];

                if (commandName == "Contains")
                {
                    int number = int.Parse(commandParts[1]);
                    numbers.Contains(number);

                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commandName == "PrintEven")
                {
                    foreach (var number in numbers)
                    {
                        bool isEven = number % 2 == 0;
                        if (isEven)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (commandName == "PrintOdd")
                {
                    foreach (var number in numbers)
                    {
                        bool isOdd = number % 2 == 1;
                        if (isOdd)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (commandName == "GetSum")
                {
                    int sum = 0;
                    foreach (var number in numbers)
                    {
                        sum += number;
                    }
                    Console.WriteLine(sum);
                }
                else if (commandName == "Filter")
                {
                    string condition = commandParts[1];
                    int number = int.Parse(commandParts[2]);
                    
                    if (condition == ">")
                    {
                        numbers.RemoveAll(x => x <= number);
                    }
                    else if (condition == "<")
                    {
                        numbers.RemoveAll(x => x >= number);
                    }
                    else if (condition == ">=")
                    {
                        numbers.RemoveAll(x => x < number);
                    }
                    else if (condition == "<=")
                    {
                        numbers.RemoveAll(x => x > number);
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

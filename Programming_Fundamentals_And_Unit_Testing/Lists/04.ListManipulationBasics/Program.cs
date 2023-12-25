using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListManipulationBasics
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

                if (commandName == "Add")
                {
                    int number = GetNumber(commandParts);
                    numbers.Add(number);
                }
                else if (commandName == "Remove")
                {
                    int number = int.Parse(commandParts[1]);
                    numbers.Remove(number);
                }
                else if (commandName == "RemoveAt")
                {
                    int index = GetIndex(commandParts);
                    numbers.RemoveAt(index);
                }
                else if (commandName == "Insert")
                {
                    int number = int.Parse(commandParts[1]);
                    int index = int.Parse(commandParts[2]);
                    numbers.Insert(index, number);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int GetIndex(string[] commandParts)
        {
            return int.Parse(commandParts[1]);
        }

        private static int GetNumber(string[] commandParts)
        {
            return int.Parse(commandParts[1]);
        }
    }
}

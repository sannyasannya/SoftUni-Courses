using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ChangeList
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
                string[] commandPart = command.Split(" ");
                string commandName = commandPart[0];
                int element = int.Parse(commandPart[1]);

                if (commandName == "Delete")
                {
                    numbers.RemoveAll(number => number == element);
                }
                else if (commandName == "Insert")
                {
                    int position = int.Parse(commandPart[2]);
                    numbers.Insert(position, element);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}

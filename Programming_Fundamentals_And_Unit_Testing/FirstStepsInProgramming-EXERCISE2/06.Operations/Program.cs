﻿using System;

namespace _06.Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double result = 0.0;
            string evenOrOdd = string.Empty;

            if (symbol == '+')
            {
                result = n1 + n2;

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOrOdd}");
            }
            else if (symbol == '-')
            {
                result = n1 - n2;

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";                   

                }
                Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOrOdd}");
            }
            else if (symbol == '*')
            {
                result = n1 * n2;

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }

                Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOrOdd}");
            }
            else if (symbol == '/')
            {
                result = n1 / n2;

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result:f2}");
                }
                
            }
            else if (symbol == '%')
            {
                result = n1 % n2;

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result}");
                }               

            }
           
        }
    }
}

﻿namespace _06.IncToCentm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double cm = inches * 2.54;

            Console.WriteLine(cm);
        }
    }
}
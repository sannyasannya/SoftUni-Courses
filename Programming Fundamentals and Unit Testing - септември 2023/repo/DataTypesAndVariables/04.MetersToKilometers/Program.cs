﻿namespace _04.MetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double km = meters / 1000;

            Console.WriteLine($"{km:f2}");

        }
    }
}
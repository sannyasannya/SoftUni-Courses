﻿using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();
            int number = 1;

            foreach (var product in products)
            {
                Console.WriteLine($"{number++}.{product}");
            }
        }
    }
}

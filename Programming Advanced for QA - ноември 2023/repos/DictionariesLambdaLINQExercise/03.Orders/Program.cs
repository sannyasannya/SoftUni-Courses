﻿namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> products = new();

            string input = Console.ReadLine();

            while (input != "buy") 
            {
                string[] inputArray = input.Split();
                string product = inputArray[0];
                decimal price = decimal.Parse(inputArray[1]);
                decimal quantity = decimal.Parse(inputArray[2]);

                if (products.ContainsKey(product)) 
                {
                    products[product][0] = price;
                    products[product][1] += quantity;
                }
                else
                {
                    products.Add(product, new List<decimal>());
                    products[product].Add(price);
                    products[product].Add(quantity);
                }
                input = Console.ReadLine();
            }

            foreach (KeyValuePair < string, List<decimal>> currentProduct in products) 
            {
                string currentproductName = currentProduct.Key;
                decimal currentProductPrice = currentProduct.Value[0];
                decimal currentProductQuantity = currentProduct.Value[1];

                decimal currentProductAmount = currentProductPrice * currentProductQuantity;
                Console.WriteLine($"{currentproductName} -> {currentProductAmount:f2}");
            }
        }
    }
}
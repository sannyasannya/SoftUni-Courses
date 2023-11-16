using System;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (product)
            {
                case "coffee":
                    if (town == "Sofia")
                    {
                        price = 0.5;
                    }
                    else if (town == "Plovdiv")
                    {
                        price = 0.4;
                    }
                    else if (town == "Varna")
                    {
                        price = 0.45;
                    }                    
                    break;

                case "water":
                    if (town == "Sofia")
                    {
                        price = 0.8;
                    }
                    else if (town == "Plovdiv")
                    {
                        price = 0.7;
                    }
                    else if (town == "Varna")
                    {
                        price = 0.7;
                    }
                    break;

                case "beer":
                    if (town == "Sofia")
                    {
                        price = 1.2;
                    }
                    else if (town == "Plovdiv")
                    {
                        price = 1.15;
                    }
                    else if (town == "Varna")
                    {
                        price = 1.1;
                    }
                    break;

                case "sweets":
                    if (town == "Sofia")
                    {
                        price = 1.45;
                    }
                    else if (town == "Plovdiv")
                    {
                        price = 1.3;
                    }
                    else if (town == "Varna")
                    {
                        price = 1.35;
                    }
                    break;

                case "peanuts":
                    if (town == "Sofia")
                    {
                        price = 1.6;
                    }
                    else if (town == "Plovdiv")
                    {
                        price = 1.5;
                    }
                    else if (town == "Varna")
                    {
                        price = 1.55;
                    }
                    break;
            }
            double finalPrice = quantity * price;
            Console.WriteLine(finalPrice);

        }
    }
}

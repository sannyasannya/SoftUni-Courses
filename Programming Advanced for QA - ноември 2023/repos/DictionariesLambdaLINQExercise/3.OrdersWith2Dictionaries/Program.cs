namespace _3.OrdersWith2Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrice = new();
            Dictionary<string, int> productQuantity = new();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] inputArray = input.Split();
                string product = inputArray[0];
                decimal price = decimal.Parse(inputArray[1]);
                int quantity = int.Parse(inputArray[2]);

                if (productPrice.ContainsKey(product))
                {
                    productPrice[product] = price;
                    productQuantity[product] += quantity;
                }
                else
                {
                   productPrice.Add(product, price);
                    productQuantity.Add(product, quantity);
                }
                input = Console.ReadLine();
            }

            foreach (string currentProduct in productPrice.Keys)
            {
                Console.WriteLine($"{currentProduct} -> " +
                    $"{(productPrice[currentProduct] * productQuantity[currentProduct]):f2}");
            }
            
        }
    }
}
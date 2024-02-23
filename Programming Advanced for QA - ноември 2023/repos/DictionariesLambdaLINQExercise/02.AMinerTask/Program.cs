using System.Collections;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new();

            string resource = Console.ReadLine();


            while (resource != "stop") 
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource)) 
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }

                resource = Console.ReadLine();
               
            }

            foreach (KeyValuePair<string, int> pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
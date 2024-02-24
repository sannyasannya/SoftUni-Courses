namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registrars = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArray = Console.ReadLine().Split().ToArray();

                string command = commandArray[0];
                string employee = commandArray[1];

                if (command == "register")
                {
                    string plateNumber = commandArray[2];

                    if (registrars.ContainsKey(employee)) 
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registrars[employee]}");
                    }
                    else
                    {
                        registrars.Add(employee, plateNumber);
                        Console.WriteLine($"{employee} registered {plateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {                   

                    if (registrars.ContainsKey(employee))
                    {
                        registrars.Remove(employee);
                        Console.WriteLine($"{employee} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {employee} not found");
                    }
                }
            }
            foreach (KeyValuePair<string, string> pair in registrars)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }

        }
            

    }
}
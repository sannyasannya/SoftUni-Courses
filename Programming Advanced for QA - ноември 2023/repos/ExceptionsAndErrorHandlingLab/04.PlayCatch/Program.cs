namespace _04.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                             .Split(" ")
                             .Select(int.Parse)
                             .ToArray();

            string command = Console.ReadLine();
            int numOfExceptions = 0;

            while (numOfExceptions < 3)
            {
                string[] commandParams = command.Split();

                try
                {

                    if (commandParams[0] == "Replace")
                    {
                        int index = int.Parse(commandParams[1]);
                        int element = int.Parse(commandParams[2]);

                        integers[index] = element;
                    }
                    else if (commandParams[0] == "Print")
                    {
                        int startIndex = int.Parse(commandParams[1]);
                        int endIndex = int.Parse(commandParams[2]);

                        int[] toPrint = new int[endIndex - startIndex + 1];
                        int counter = 0;

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            toPrint[counter] = integers[i];
                            counter++;
                        }
                        Console.WriteLine(string.Join(", ", toPrint));
                    }
                    else if (commandParams[0] == "Show")
                    {
                        int index = int.Parse(commandParams[1]);
                        Console.WriteLine(integers[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    numOfExceptions++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    numOfExceptions++;
                    
                }
                finally 
                {
                    if(numOfExceptions < 3)
                    {
                        command = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
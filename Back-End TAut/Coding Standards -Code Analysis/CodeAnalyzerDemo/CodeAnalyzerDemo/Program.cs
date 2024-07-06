/// <summary>
/// This is the main class of the Program.
/// </summary>
/// 
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hi!");
        Console.WriteLine(MakeGreeting("Sanya!"));
    }    
    private static string MakeGreeting(string name)
    {
        if (name == null) // No braces and spacing issues
        {
            throw new ArgumentNullException(paramName: nameof(name));
        }

        return "Hello, " + name;
    }
}

namespace _03.RectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int widht = int.Parse(Console.ReadLine());

            int area = lenght * widht;

            Console.WriteLine(area);
        }
    }
}
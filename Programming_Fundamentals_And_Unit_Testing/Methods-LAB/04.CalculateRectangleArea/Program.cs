using System;

namespace _04.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            RectangleArea(widht, lenght);
        }
        static void RectangleArea(int widht, int lenght)
        {
            int area = widht * lenght;
            Console.WriteLine(area);
        }
    }
}

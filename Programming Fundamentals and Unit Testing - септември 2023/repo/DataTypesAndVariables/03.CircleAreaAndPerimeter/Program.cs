namespace _03.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radiusOfCircle = double.Parse(Console.ReadLine());
            double area = radiusOfCircle * radiusOfCircle * Math.PI;
            double perimeter = 2 * Math.PI * radiusOfCircle;

            Console.WriteLine($"Area = {area:f2}");
            Console.WriteLine($"Perimeter = {perimeter:f2}");
        }
    }
}
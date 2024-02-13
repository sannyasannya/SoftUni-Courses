namespace _04.Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bathroomWidth = double.Parse(Console.ReadLine());
            double bathroomHeight = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileHeight = double.Parse(Console.ReadLine());

            double bathroomArea = bathroomWidth * bathroomHeight;
            double tileSurplus = bathroomArea + (0.1 * bathroomArea);
            double tileArea = tileWidth * tileHeight;

            double tilesNeeded = Math.Round(tileSurplus / tileArea);

            Console.WriteLine($"{tilesNeeded}");
        }
    }
}
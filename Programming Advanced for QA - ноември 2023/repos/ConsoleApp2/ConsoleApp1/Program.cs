using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Planet saturn = new Planet("Saturn", 3.5, 1056.87458, 2);
            double gravity = saturn.CalculateGravity(5555);

            string result = saturn.GetPlanetInfo();
            Console.WriteLine(result);
        }
    }

    public class Planet
    {
        private const double GravitationalConstant = 6.67430e-11;

        public Planet(string name, double diameter, double distanceFromSun, int numberOfMoons)
        {
            this.Name = name;
            this.Diameter = diameter;
            this.DistanceFromSun = distanceFromSun;
            this.NumberOfMoons = numberOfMoons;
        }

        public string Name { get; set; }

        public double Diameter { get; set; }

        public double DistanceFromSun { get; set; }

        public int NumberOfMoons { get; set; }

        public double CalculateGravity(double mass)
        {
            double radius = this.Diameter / 2.0;
            return mass * GravitationalConstant / (radius * radius);
        }

        public string GetPlanetInfo()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"Diameter: {Diameter} km");
            sb.AppendLine($"Distance from the Sun: {DistanceFromSun} km");
            sb.AppendLine($"Number of Moons: {NumberOfMoons}");

            return sb.ToString().Trim();
        }
    }
}
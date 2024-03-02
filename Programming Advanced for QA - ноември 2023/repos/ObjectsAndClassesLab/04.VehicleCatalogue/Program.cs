using System.Reflection;

namespace _04.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Catalog catalog = new Catalog();

            while (command != "end")
            {
                string[] input = command.Split("/");
                string type = input[0];
                string brand = input[1];
                string model = input[2];

                if (type == "Car")
                {
                    Car currentCar = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = int.Parse(input[3])

                    };  
                    catalog.Cars.Add(currentCar);
                }
                else if (type == "Truck")
                {
                    Truck currentTruck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = int.Parse(input[3])
                    };
                    catalog.Trucks.Add(currentTruck);
                      
                }

                command = Console.ReadLine();
            }

            if (catalog.Cars.Count > 0)
            {
                List<Car> orderedCars = catalog.Cars.OrderBy(x => x.Brand).ToList();

                Console.WriteLine("Cars:");
                foreach (Car cars in orderedCars)
                {
                    Console.WriteLine($"{cars.Brand}: {cars.Model} - {cars.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0) 
            { 
                List<Truck> orderedTrucks = catalog.Trucks.OrderBy(x => x.Brand).ToList();

                Console.WriteLine("Trucks:");
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        public class Truck
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public int Weight { get; set; }
        }

        public class Car
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public int HorsePower { get; set; }
        }

        public class Catalog
        {
            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }
            public List<Car> Cars { get; set;} 

            public List<Truck> Trucks { get; set;} 
        }
    }
}
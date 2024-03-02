namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog puppy = new Dog() 
            {
                Name = "Sparky",
                Breed = "Corgi",
                Age = 3,
            };

            Dog doggy = new Dog("Sharo", 3);

            puppy.Bark();

            Dog friend = new Dog();
            friend.Name = "Ivan";
            friend.Breed = "Unknown";
            friend.Age = 3;

            friend.Bark();
        }
    }

    

}
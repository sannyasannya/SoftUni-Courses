using System;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string password2 = Console.ReadLine();

            while (password != password2)
            {                
                password2 = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");         
        }
    }
}

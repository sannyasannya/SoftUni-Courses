using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            int count = 0;

            string currentBook = Console.ReadLine();

            while (currentBook != "No More Books")
            {               
                if (currentBook == favoriteBook)
                {
                    break;
                }
                count++;
                currentBook = Console.ReadLine();
            }

            if (currentBook == favoriteBook)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}

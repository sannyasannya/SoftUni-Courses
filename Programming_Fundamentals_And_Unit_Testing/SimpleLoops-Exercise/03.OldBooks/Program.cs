using System;

namespace _03.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int bookCounter = 0;
            string nextFindingBook = Console.ReadLine();             

            while (nextFindingBook != "No More Books")
            {               
                bookCounter++;
                nextFindingBook = Console.ReadLine();

                if (nextFindingBook == favouriteBook)
                {
                    Console.WriteLine($"You checked {bookCounter--} books and found it.");
                    return;
                }
            }        

            Console.WriteLine($"The book you search is not here!");
            Console.WriteLine($"You checked {bookCounter--} books.");          

        }
    }
}

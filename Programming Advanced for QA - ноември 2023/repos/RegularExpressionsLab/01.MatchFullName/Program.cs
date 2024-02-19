﻿using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
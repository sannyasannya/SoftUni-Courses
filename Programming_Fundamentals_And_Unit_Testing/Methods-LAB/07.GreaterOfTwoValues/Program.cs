using System;

namespace _07.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string n1 = Console.ReadLine();
            string n2 = Console.ReadLine();
            CompareStrings(type, n1, n2);
            CompareInt(type, n1, n2);
            CompareChar(type, n1, n2);
        }

        private static void CompareStrings(string type, string n1, string n2)
        {
            if (type == "string")
            {
                if (n1.CompareTo(n2) > 0)
                {
                    Console.WriteLine(n1);
                }
                else
                {
                    Console.WriteLine(n2);
                }
            }
            
        }

        private static void CompareInt(string type, string n1, string n2)
        {
            if (type == "int")
            {
                int num1 = int.Parse(n1);
                int num2 = int.Parse(n2);

                if (num1 > num2)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num2);
                }
            }
            
        }

        private static void CompareChar(string type, string n1, string n2)
        {
            if (type == "char")
            {
                char a = char.Parse(n1);
                char b = char.Parse(n2);

                if (a > b)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(b);
                }
            }
        }
    }
}

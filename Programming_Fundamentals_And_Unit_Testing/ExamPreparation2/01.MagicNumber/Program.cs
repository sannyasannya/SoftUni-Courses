namespace _01.MagicNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1;  i <= n; i++)
            {
                bool isPrime = true;
                int divider = 2;
                
                while (divider < n) 
                {
                    if (i == divider)
                    {
                        divider++;
                        continue;
                    }

                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    divider++;
                }
                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }


            

        }
    }
}
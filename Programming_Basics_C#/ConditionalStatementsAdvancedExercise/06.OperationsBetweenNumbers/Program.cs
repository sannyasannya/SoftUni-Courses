namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string mathOperator = Console.ReadLine();
            string numType = string.Empty;


            double result = 0;

            if (mathOperator == "+")
            {
                result = num1 + num2;
            }
            else if (mathOperator == "-")
            {
                result = num1 - num2;
            }
            else if (mathOperator == "*")
            {
                result = num1 * num2;
            }
            else if (mathOperator == "/")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                    return;
                }

                result = (double)num1 / num2;
            }
            else if (mathOperator == "%")
            {

                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                    return;
                }

                result = num1 % num2;
            }

            if (result % 2 == 0)
            {
                numType = "even";
            }
            else
            {
                numType = "odd";
            }

            if (mathOperator == "/")
            {
                Console.WriteLine($"{num1} {mathOperator} {num2} = {result:f2}");
            }
            else if (mathOperator == "%")
            {
                Console.WriteLine($"{num1} {mathOperator} {num2} = {result}");
            }
            else
            {
                Console.WriteLine($"{num1} {mathOperator} {num2} = {result} - {numType}");
            }
        }
    }
}
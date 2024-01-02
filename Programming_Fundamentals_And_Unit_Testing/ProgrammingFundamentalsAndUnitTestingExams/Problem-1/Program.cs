namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double sumGrade = 0;

            for (int i = 1; i <= num; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                sumGrade += grade;
            }             

            double averageGrade = sumGrade / num;
            Console.WriteLine($"{averageGrade:f2}");
        }
    }
}
namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());

            int savedMoney = 0;
            int giftedMoney = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    savedMoney += toysPrice;
                }
                else
                {
                    savedMoney = (savedMoney + giftedMoney) - 1;
                    giftedMoney += 10;
                }
            }

            if (savedMoney >= washingMachinePrice)
            {
                double remaingMoney = savedMoney - washingMachinePrice;
                Console.WriteLine($"Yes! {remaingMoney:f2}");
            }
            else
            {
                double requiredMoney = washingMachinePrice - savedMoney;
                Console.WriteLine($"No! {requiredMoney:f2}");
            }



        }
    }
}
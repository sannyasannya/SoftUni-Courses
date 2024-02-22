namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary<string, string> phoneBook = new();

            // phoneBook.Add("Sanya Panova", "+359883517682");

            // if (!phoneBook.ContainsKey("Deni")) 
            //{
            //    phoneBook.Add("Deni", "0883516682");
            // }


            // string value = phoneBook["Deni"];

            //Console.WriteLine(value);

            // за оптимизиране на информацията
            //phoneBook["Sanya Panova"] = "088351515168";

            // Console.WriteLine(phoneBook["Sanya Panova"]);




            //var fruits = new SortedDictionary<string, double>();
            //fruits["kiwi"] = 4.50;
            //fruits["orange"] = 2.50;
            //fruits["banana"] = 2.20;

            //foreach (var fruit in fruits)
            //{
            //    Console.WriteLine($"{fruit.Key} - {fruit.Value}");
            //}

            // foreach(KeyValuePair<string, double> fruit in fruits)
            //{
            //  Console.WriteLine($"{fruit.Key} - {fruit.Value}");
            //}



            List<string> names = new() { "Sanya", "Deni", "Kamen", "Vladi" };

            // var result = names.Select(x => x + ":)");

            //var result = names.Select(x => x.ToLower());

            //var result = names.Select(x => x.ToUpper());

            var result = names.Select(x => $"{x}xaxaxa");
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
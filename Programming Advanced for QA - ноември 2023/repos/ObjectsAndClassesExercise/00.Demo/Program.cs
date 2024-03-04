namespace _00.Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string articleData = Console.ReadLine();
            string[] data = articleData.Split(", ");
            string title = data[0];
            string content = data[1];
            string author = data[2];

            Article article = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();
                string[] commandParts = command.Split(": ");
                string commandName = commandParts[0];
                string commandParameter = commandParts[1];

                if (commandName == "Edit")
                {
                    article.Edit(commandParameter);
                }
                else if (commandName == "ChangeAuthor")
                {
                    article.ChangeAuthor(commandParameter);
                }
                else if (commandName == "Rename")
                {
                    article.Rename(commandParameter);
                }
            }

            Console.WriteLine(article.ToString());


        }
    }
}